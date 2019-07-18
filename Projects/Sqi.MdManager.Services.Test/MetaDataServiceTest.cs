using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Sqi.Framework;
using Sqi.Framework.Models;
using Sqi.Framework.Models.Core;
using Sqi.Framework.Repositories;
using Sqi.Framework.Repositories.Mocks;
using Sqi.Framework.Services;
using Sqi.Framework.Services.Core;
using Sqi.MdManager.Services.Core;

namespace Sqi.MdManager.Services.Test
{
    [TestFixture]
    public class MetaDataServiceTest
    {
        #region Fields

        private const int INTEGER_DEFAULT_VALUE = 42;
        private const string META_ENTITY_INTERFACE_NAME = "IMetaEntity";
        private const string REGULAR_EXPRESSION_INTERFACE_NAME = "IRegularExpression";

        private const string REGULAR_EXPRESSION_PATTERN =
            @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))";

        private const string STRING_DEFAULT_VALUE = "DefaultValue";
        private const string STRING_META_FIELD_NAME = "Label";

        #endregion

        #region Properties

        private InstanceLocator InstanceLocator { get; } = InstanceLocator.Current;
        private IModelFactory ModelFactory { get; set; }
        private DateTime Now { get; set; }
        private MetaModelRepository Repository { get; set; }

        #endregion

        #region Setup / Teardown

        [SetUp]
        public void SetUp()
        {
            InstanceLocator.RegisterInstance<IModelFactory, ModelFactory>();
            ModelFactory = InstanceLocator.GetInstance<IModelFactory>();
            Repository = new MetaModelRepository();
            InstanceLocator.RegisterInstance<IMetaModelRepository>(Repository);
            InstanceLocator.RegisterInstance<IEntityService, EntityService>();

            Now = DateTime.Now;

            InitializeMetaModel();
        }

        [TearDown]
        public void TearDown()
        {
            InstanceLocator.ClearInstances();
        }

        #endregion

        #region Tests

        [Test]
        public void TestGetMetaEntities()
        {
            var metaDataService = new MetaDataService();
            var metaEntities = Repository.MetaEntities;

            var foundMetaEntities = metaDataService.GetMetaEntities();

            Assert.AreSame(metaEntities, foundMetaEntities);
        }

        [Test]
        public void TestGetRegularExpression()
        {
            var metaDataService = new MetaDataService();
            var regularExpression = Repository.RegularExpressions.First();

            var foundRegularExpression = metaDataService.GetRegularExpression(1);

            Assert.AreSame(regularExpression, foundRegularExpression);
        }

        [Test]
        public void TestGetRegularExpressions()
        {
            var metaDataService = new MetaDataService();
            var regularExpressions = Repository.RegularExpressions;

            var foundRegularExpressions = metaDataService.GetRegularExpressions();

            Assert.AreSame(regularExpressions, foundRegularExpressions);
        }

        [Test]
        public void TestInitializeMetaEntity()
        {
            var metaDataService = new MetaDataService();
            var metaEntity = Repository.MetaEntities.First();

            var entity = metaDataService.InitializeMetaEntity(metaEntity);

            Assert.NotNull(entity);
            Assert.AreEqual(INTEGER_DEFAULT_VALUE, entity.Id);
            Assert.AreEqual(STRING_DEFAULT_VALUE, entity.Label);
        }

        [Test]
        public void TestInitializeRegularExpression()
        {
            var metaDataService = new MetaDataService();
            var metaEntity = Repository.MetaEntities.First();

            var regularExpression = metaDataService.InitializeRegularExpression(metaEntity);

            Assert.NotNull(regularExpression);
            Assert.AreEqual(INTEGER_DEFAULT_VALUE, regularExpression.Id);
            Assert.AreEqual(STRING_DEFAULT_VALUE, regularExpression.Label);
        }

        [Test]
        public void TestSaveMetaEntityCreate()
        {
            var metaDataService = new MetaDataService();
            var metaEntity = Repository.MetaEntities.First();
            var entityValidator = new EntityValidator(metaEntity);
            var metaField = Repository.MetaFields.Single(mf => mf.Id == 1);
            var intFieldValidator = new FieldValidator<int?>(metaField, entityValidator);
            intFieldValidator.ValueCheckings.Add(CheckValue);
            entityValidator.FieldValidators.Add(intFieldValidator);
            metaField = Repository.MetaFields.Single(mf => mf.Id == 2);
            var stringFieldValidator = new FieldValidator<string>(metaField, entityValidator);
            stringFieldValidator.ValueCheckings.Add(CheckValue);
            entityValidator.FieldValidators.Add(stringFieldValidator);
            metaEntity = CreateMetaEntity();

            var results = metaDataService.SaveMetaEntity(entityValidator, metaEntity);

            Assert.IsNotEmpty(results);
            Assert.AreEqual(2, results.Count);
            CollectionAssert.AllItemsAreNotNull(results);
            Assert.True(results.All(r => r.IsValid));
            Assert.AreEqual(2, Repository.MetaEntities.Count);
            CollectionAssert.Contains(Repository.MetaEntities, metaEntity);
            Assert.AreEqual(2, metaEntity.Id);
            Assert.AreNotEqual(DateTime.MinValue, metaEntity.CreationDate);
            Assert.NotNull(metaEntity.CreationUser);
            Assert.AreNotEqual(DateTime.MinValue, metaEntity.LastUpdateDate);
            Assert.NotNull(metaEntity.LastUpdateUser);
            Assert.AreEqual(metaEntity.CreationDate, metaEntity.LastUpdateDate);
            Assert.AreSame(metaEntity.CreationUser, metaEntity.LastUpdateUser);
        }

        [Test]
        public void TestSaveMetaEntityUpdate()
        {
            var metaDataService = new MetaDataService();
            var metaEntity = Repository.MetaEntities.First();
            var entityValidator = new EntityValidator(metaEntity);
            var metaField = Repository.MetaFields.Single(mf => mf.Id == 1);
            var intFieldValidator = new FieldValidator<int?>(metaField, entityValidator);
            intFieldValidator.ValueCheckings.Add(CheckValue);
            entityValidator.FieldValidators.Add(intFieldValidator);
            metaField = Repository.MetaFields.Single(mf => mf.Id == 2);
            var stringFieldValidator = new FieldValidator<string>(metaField, entityValidator);
            stringFieldValidator.ValueCheckings.Add(CheckValue);
            entityValidator.FieldValidators.Add(stringFieldValidator);
            metaEntity.Label = "New Label";

            var results = metaDataService.SaveMetaEntity(entityValidator, metaEntity);

            Assert.IsNotEmpty(results);
            Assert.AreEqual(2, results.Count);
            CollectionAssert.AllItemsAreNotNull(results);
            Assert.True(results.All(r => r.IsValid));
            Assert.AreEqual(1, Repository.MetaEntities.Count);
            CollectionAssert.Contains(Repository.MetaEntities, metaEntity);
            Assert.AreEqual(1, metaEntity.Id);
            Assert.AreNotEqual(DateTime.MinValue, metaEntity.LastUpdateDate);
            Assert.NotNull(metaEntity.LastUpdateUser);
            Assert.AreNotEqual(metaEntity.CreationDate, metaEntity.LastUpdateDate);
            Assert.AreSame(metaEntity.CreationUser, metaEntity.LastUpdateUser);
        }

        [Test]
        public void TestSaveMetaFieldCreate()
        {
            var metaDataService = new MetaDataService();
            var metaEntity = Repository.MetaEntities.First();
            var entityValidator = new EntityValidator(metaEntity);
            var metaField = Repository.MetaFields.Single(mf => mf.Id == 1);
            var intFieldValidator = new FieldValidator<int?>(metaField, entityValidator);
            intFieldValidator.ValueCheckings.Add(CheckValue);
            entityValidator.FieldValidators.Add(intFieldValidator);
            metaField = Repository.MetaFields.Single(mf => mf.Id == 2);
            var stringFieldValidator = new FieldValidator<string>(metaField, entityValidator);
            stringFieldValidator.ValueCheckings.Add(CheckValue);
            entityValidator.FieldValidators.Add(stringFieldValidator);
            metaField = CreateMetaField(metaEntity);

            var results = metaDataService.SaveMetaField(entityValidator, metaField);

            Assert.IsNotEmpty(results);
            Assert.AreEqual(2, results.Count);
            CollectionAssert.AllItemsAreNotNull(results);
            Assert.True(results.All(r => r.IsValid));
            Assert.AreEqual(3, Repository.MetaFields.Count);
            CollectionAssert.Contains(Repository.MetaFields, metaField);
            Assert.AreEqual(3, metaField.Id);
            Assert.AreNotEqual(DateTime.MinValue, metaField.CreationDate);
            Assert.NotNull(metaField.CreationUser);
            Assert.AreNotEqual(DateTime.MinValue, metaField.LastUpdateDate);
            Assert.NotNull(metaField.LastUpdateUser);
            Assert.AreEqual(metaField.CreationDate, metaField.LastUpdateDate);
            Assert.AreSame(metaField.CreationUser, metaField.LastUpdateUser);
        }

        [Test]
        public void TestSaveMetaFieldUpdate()
        {
            var metaDataService = new MetaDataService();
            var metaEntity = Repository.MetaEntities.First();
            var entityValidator = new EntityValidator(metaEntity);
            var metaField = Repository.MetaFields.Single(mf => mf.Id == 1);
            var intFieldValidator = new FieldValidator<int?>(metaField, entityValidator);
            intFieldValidator.ValueCheckings.Add(CheckValue);
            entityValidator.FieldValidators.Add(intFieldValidator);
            metaField = Repository.MetaFields.Single(mf => mf.Id == 2);
            var stringFieldValidator = new FieldValidator<string>(metaField, entityValidator);
            stringFieldValidator.ValueCheckings.Add(CheckValue);
            entityValidator.FieldValidators.Add(stringFieldValidator);
            metaField.Label = "New label";

            var results = metaDataService.SaveMetaField(entityValidator, metaField);

            Assert.IsNotEmpty(results);
            Assert.AreEqual(2, results.Count);
            CollectionAssert.AllItemsAreNotNull(results);
            Assert.True(results.All(r => r.IsValid));
            Assert.AreEqual(2, Repository.MetaFields.Count);
            CollectionAssert.Contains(Repository.MetaFields, metaField);
            Assert.AreEqual(2, metaField.Id);
            Assert.AreNotEqual(DateTime.MinValue, metaField.CreationDate);
            Assert.NotNull(metaField.CreationUser);
            Assert.AreNotEqual(DateTime.MinValue, metaField.LastUpdateDate);
            Assert.NotNull(metaField.LastUpdateUser);
            Assert.AreNotEqual(metaField.CreationDate, metaField.LastUpdateDate);
            Assert.AreSame(metaField.CreationUser, metaField.LastUpdateUser);
        }

        [Test]
        public void TestSaveRegularExpressionCreate()
        {
            // TODO TestSaveRegularExpressionCreate
            Assert.Ignore();
            //var metaDataService = new MetaDataService();
            //var regularExpression = Repository.RegularExpressions.First();
            //var entityValidator = new EntityValidator(regularExpression as IMetaEntity);
            //var metaField = Repository.MetaFields.Single(mf => mf.Id == 1);
            //var intFieldValidator = new FieldValidator<int?>(metaField, entityValidator);
            //intFieldValidator.ValueCheckings.Add(CheckValue);
            //entityValidator.FieldValidators.Add(intFieldValidator);
            //metaField = Repository.MetaFields.Single(mf => mf.Id == 2);
            //var stringFieldValidator = new FieldValidator<string>(metaField, entityValidator);
            //stringFieldValidator.ValueCheckings.Add(CheckValue);
            //entityValidator.FieldValidators.Add(stringFieldValidator);
            //regularExpression = CreateRegularExpression();

            //var results = metaDataService.SaveRegularExpression(entityValidator, regularExpression);

            //Assert.IsNotEmpty(results);
            //Assert.AreEqual(2, results.Count);
            //CollectionAssert.AllItemsAreNotNull(results);
            //Assert.True(results.All(r => r.IsValid));
            //Assert.AreEqual(3, Repository.RegularExpressions.Count);
            //CollectionAssert.Contains(Repository.RegularExpressions, regularExpression);
            //Assert.AreEqual(3, regularExpression.Id);
            //Assert.AreNotEqual(DateTime.MinValue, regularExpression.CreationDate);
            //Assert.NotNull(regularExpression.CreationUser);
            //Assert.AreNotEqual(DateTime.MinValue, regularExpression.LastUpdateDate);
            //Assert.NotNull(regularExpression.LastUpdateUser);
            //Assert.AreEqual(regularExpression.CreationDate, regularExpression.LastUpdateDate);
            //Assert.AreSame(regularExpression.CreationUser, regularExpression.LastUpdateUser);
        }

        [Test]
        public void TestSaveRegularExpressionUpdate()
        {
            // TODO TestSaveRegularExpressionUpdate
            var regularExpression = CreateRegularExpression();
            Assert.NotNull(regularExpression);
            Assert.Ignore();
            //var metaDataService = new MetaDataService();
            //var regularExpression = Repository.RegularExpressions.First();
            //var entityValidator = new EntityValidator(regularExpression as IMetaEntity);
            //var metaField = Repository.MetaFields.Single(mf => mf.Id == 1);
            //var intFieldValidator = new FieldValidator<int?>(metaField, entityValidator);
            //intFieldValidator.ValueCheckings.Add(CheckValue);
            //entityValidator.FieldValidators.Add(intFieldValidator);
            //metaField = Repository.MetaFields.Single(mf => mf.Id == 2);
            //var stringFieldValidator = new FieldValidator<string>(metaField, entityValidator);
            //stringFieldValidator.ValueCheckings.Add(CheckValue);
            //entityValidator.FieldValidators.Add(stringFieldValidator);
            //regularExpression.Label = "New regular expression";

            //var results = metaDataService.SaveRegularExpression(entityValidator, regularExpression);

            //Assert.IsNotEmpty(results);
            //Assert.AreEqual(2, results.Count);
            //CollectionAssert.AllItemsAreNotNull(results);
            //Assert.True(results.All(r => r.IsValid));
            //Assert.AreEqual(2, Repository.RegularExpressions.Count);
            //CollectionAssert.Contains(Repository.RegularExpressions, regularExpression);
            //Assert.AreEqual(1, regularExpression.Id);
            //Assert.AreNotEqual(DateTime.MinValue, regularExpression.CreationDate);
            //Assert.NotNull(regularExpression.CreationUser);
            //Assert.AreNotEqual(DateTime.MinValue, regularExpression.LastUpdateDate);
            //Assert.NotNull(regularExpression.LastUpdateUser);
            //Assert.AreEqual(regularExpression.CreationDate, regularExpression.LastUpdateDate);
            //Assert.AreSame(regularExpression.CreationUser, regularExpression.LastUpdateUser);
        }

        #endregion

        #region Methods

        private ValueCheckingResult CheckValue<TValue>(IFieldValidator<TValue> fieldValidator, TValue value)
        {
            var result = new ValueCheckingResult(fieldValidator.MetaField.Id.ToString());
            if (fieldValidator.MetaField.IsRequired && value == null)
            {
                result.InvalidMessage = "InvalidMessage";
            }

            return result;
        }

        private IMetaEntity CreateMetaEntity() => ModelFactory.CreateMetaEntity(
            META_ENTITY_INTERFACE_NAME,
            "New label",
            "New plurial label",
            true,
            "New description...");

        private IMetaField CreateMetaField(IMetaEntity metaEntity)
        {
            var metaField = ModelFactory.CreateStringMetaField(
                STRING_META_FIELD_NAME,
                "New label",
                "New Description...",
                true,
                false,
                true,
                null,
                false,
                1,
                null,
                1,
                STRING_DEFAULT_VALUE
            );
            metaField.MetaEntity = metaEntity;
            return metaField;
        }

        private IRegularExpression CreateRegularExpression() => ModelFactory.CreateRegularExpression(
            REGULAR_EXPRESSION_INTERFACE_NAME,
            REGULAR_EXPRESSION_PATTERN,
            "New Description expression régulière",
            "Ce champ ne respecte pas les critères définis pour une adresse mail");

        private void InitializeMetaModel()
        {
            var user = ModelFactory.CreateMdUser(1, "admin");
            Repository.Users.Add(user);

            var metaEntity = ModelFactory.CreateMetaEntity(
                META_ENTITY_INTERFACE_NAME,
                "Entity label",
                "Plurial entity label",
                true,
                "Description entity...");
            metaEntity.Id = 1;
            metaEntity.CreationDate = Now;
            metaEntity.CreationUser = user;
            metaEntity.LastUpdateDate = Now;
            metaEntity.LastUpdateUser = user;
            metaEntity.MetaFields = new List<IMetaField>();
            Repository.MetaEntities.Add(metaEntity);

            IMetaField metaField = ModelFactory.CreateIntegerMetaField(
                "Id",
                "Integer field label",
                "Description integer field...",
                true,
                true,
                true,
                null,
                false,
                1,
                999999,
                INTEGER_DEFAULT_VALUE);
            metaField.Id = 1;
            metaField.CreationDate = Now;
            metaField.CreationUser = user;
            metaField.LastUpdateDate = Now;
            metaField.LastUpdateUser = user;
            metaField.MetaEntity = metaEntity;
            metaEntity.MetaFields.Add(metaField);
            Repository.MetaFields.Add(metaField);
            metaField = ModelFactory.CreateStringMetaField(
                STRING_META_FIELD_NAME,
                "String field label",
                "Description string field...",
                true,
                false,
                true,
                null,
                false,
                1,
                null,
                1,
                STRING_DEFAULT_VALUE
            );
            metaField.Id = 2;
            metaField.CreationDate = Now;
            metaField.CreationUser = user;
            metaField.LastUpdateDate = Now;
            metaField.LastUpdateUser = user;
            metaField.MetaEntity = metaEntity;
            metaEntity.MetaFields.Add(metaField);
            Repository.MetaFields.Add(metaField);

            var regurlarExpression1 = ModelFactory.CreateRegularExpression(
                REGULAR_EXPRESSION_INTERFACE_NAME,
                REGULAR_EXPRESSION_PATTERN,
                "Description expression régulière",
                "Ce champ ne respecte pas les critères définis pour une adresse");

            regurlarExpression1.Id = 1;
            regurlarExpression1.CreationDate = Now;
            regurlarExpression1.CreationUser = user;
            regurlarExpression1.LastUpdateDate = Now;
            regurlarExpression1.LastUpdateUser = user;
            Repository.RegularExpressions.Add(regurlarExpression1);

            var regurlarExpression2 = ModelFactory.CreateRegularExpression(
                REGULAR_EXPRESSION_INTERFACE_NAME,
                REGULAR_EXPRESSION_PATTERN,
                "New Description expression régulière",
                "Ce champ ne respecte pas les critères définis ...");

            regurlarExpression2.Id = 2;
            regurlarExpression2.CreationDate = Now;
            regurlarExpression2.CreationUser = user;
            regurlarExpression1.LastUpdateDate = Now;
            regurlarExpression1.LastUpdateUser = user;
            Repository.RegularExpressions.Add(regurlarExpression2);
        }

        #endregion
    }
}