using Sqi.Framework;
using Sqi.Framework.Models;
using Sqi.Framework.Repositories;
using Sqi.Framework.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sqi.MdManager.Services.Core
{
    public class MetaDataService : IMetaDataService
    {
        #region Fields

        private const string DEFAULT_USER_LOGIN = "admin";

        #endregion

        #region Properties

        private IEntityService EntityService { get; } = InstanceLocator.Current.GetInstance<IEntityService>();

        private IMetaModelRepository MetaModelRepository { get; } =
            InstanceLocator.Current.GetInstance<IMetaModelRepository>();

        private IModelFactory ModelFactory { get; } = InstanceLocator.Current.GetInstance<IModelFactory>();

        #endregion

        #region Methods

        public IList<IMetaEntity> GetMetaEntities() => MetaModelRepository.GetMetaEntities();
        public IList<IMetaField> GetMetaFieldTemplates() => MetaModelRepository.GetMetaFieldTemplates();
        public IRegularExpression GetRegularExpression(int id) => MetaModelRepository.GetRegularExpression(id);

        public IList<IRegularExpression> GetRegularExpressions() => MetaModelRepository.GetRegularExpressions();

        public IBooleanMetaField InitializeBooleanMetaField(IMetaEntity metaMetaField, IMetaEntity metaEntity)
        {
            var booleanMetaField = ModelFactory.CreateBooleanMetaField();
            EntityService.SetEntityDefaultValues(booleanMetaField, metaMetaField);
            var now = DateTime.Now;
            var user = MetaModelRepository.GetMdUser(DEFAULT_USER_LOGIN);
            booleanMetaField.MetaEntity = metaEntity;
            booleanMetaField.CreationDate = now;
            booleanMetaField.CreationUser = user;
            booleanMetaField.LastUpdateDate = now;
            booleanMetaField.LastUpdateUser = user;
            return booleanMetaField;
        }

        public IDateTimeMetaField InitializeDateTimeMetaField(IMetaEntity metaMetaField, IMetaEntity metaEntity)
        {
            var dateTimeMetaField = ModelFactory.CreateDateTimeMetaField();
            EntityService.SetEntityDefaultValues(dateTimeMetaField, metaMetaField);
            var now = DateTime.Now;
            var user = MetaModelRepository.GetMdUser(DEFAULT_USER_LOGIN);
            dateTimeMetaField.MetaEntity = metaEntity;
            dateTimeMetaField.CreationDate = now;
            dateTimeMetaField.CreationUser = user;
            dateTimeMetaField.LastUpdateDate = now;
            dateTimeMetaField.LastUpdateUser = user;
            return dateTimeMetaField;
        }

        public IDecimalMetaField InitializeDecimalMetaField(IMetaEntity metaMetaField, IMetaEntity metaEntity)
        {
            var decimalMetaField = ModelFactory.CreateDecimalMetaField();
            EntityService.SetEntityDefaultValues(decimalMetaField, metaMetaField);
            var now = DateTime.Now;
            var user = MetaModelRepository.GetMdUser(DEFAULT_USER_LOGIN);
            decimalMetaField.MetaEntity = metaEntity;
            decimalMetaField.CreationDate = now;
            decimalMetaField.CreationUser = user;
            decimalMetaField.LastUpdateDate = now;
            decimalMetaField.LastUpdateUser = user;
            return decimalMetaField;
        }

        public IEntityMetaField InitializeEntityMetaField(IMetaEntity metaMetaField, IMetaEntity metaEntity)
        {
            var entityMetaField = ModelFactory.CreateEntityMetaField();
            EntityService.SetEntityDefaultValues(entityMetaField, metaMetaField);
            var now = DateTime.Now;
            var user = MetaModelRepository.GetMdUser(DEFAULT_USER_LOGIN);
            entityMetaField.MetaEntity = metaEntity;
            entityMetaField.CreationDate = now;
            entityMetaField.CreationUser = user;
            entityMetaField.LastUpdateDate = now;
            entityMetaField.LastUpdateUser = user;
            return entityMetaField;
        }

        public IIntegerMetaField InitializeIntegerMetaField(IMetaEntity metaMetaField, IMetaEntity metaEntity)
        {
            var integerMetaField = ModelFactory.CreateIntegerMetaField();
            EntityService.SetEntityDefaultValues(integerMetaField, metaMetaField);
            var now = DateTime.Now;
            var user = MetaModelRepository.GetMdUser(DEFAULT_USER_LOGIN);
            integerMetaField.MetaEntity = metaEntity;
            integerMetaField.CreationDate = now;
            integerMetaField.CreationUser = user;
            integerMetaField.LastUpdateDate = now;
            integerMetaField.LastUpdateUser = user;
            return integerMetaField;
        }

        public IMetaEntity InitializeMetaEntity(IMetaEntity metaMetaEntity)
        {
            var metaEntity = ModelFactory.CreateMetaEntity();
            EntityService.SetEntityDefaultValues(metaEntity, metaMetaEntity);
            var now = DateTime.Now;
            var user = MetaModelRepository.GetMdUser(DEFAULT_USER_LOGIN);
            metaEntity.CreationDate = now;
            metaEntity.CreationUser = user;
            metaEntity.LastUpdateDate = now;
            metaEntity.LastUpdateUser = user;
            return metaEntity;
        }

        public IRegularExpression InitializeRegularExpression(IMetaEntity metaRegularExpression)
        {
            var regularExpression = ModelFactory.CreateRegularExpression();
            EntityService.SetEntityDefaultValues(regularExpression, metaRegularExpression);
            var now = DateTime.Now;
            var user = MetaModelRepository.GetMdUser(DEFAULT_USER_LOGIN);
            regularExpression.CreationDate = now;
            regularExpression.CreationUser = user;
            regularExpression.LastUpdateDate = now;
            regularExpression.LastUpdateUser = user;

            return regularExpression;
        }

        public IStringMetaField InitializeStringMetaField(IMetaEntity metaMetaField, IMetaEntity metaEntity)
        {
            var stringMetaField = ModelFactory.CreateStringMetaField();
            EntityService.SetEntityDefaultValues(stringMetaField, metaMetaField);
            var now = DateTime.Now;
            var user = MetaModelRepository.GetMdUser(DEFAULT_USER_LOGIN);
            stringMetaField.MetaEntity = metaEntity;
            stringMetaField.CreationDate = now;
            stringMetaField.CreationUser = user;
            stringMetaField.LastUpdateDate = now;
            stringMetaField.LastUpdateUser = user;
            return stringMetaField;
        }

        public IBooleanMetaField InitializeBooleanMetaFieldTemplate(IMetaEntity metaMetaField)
        {
            var booleanMetaField = ModelFactory.CreateBooleanMetaField();
            EntityService.SetEntityDefaultValues(booleanMetaField, metaMetaField);
            var now = DateTime.Now;
            var user = MetaModelRepository.GetMdUser(DEFAULT_USER_LOGIN);
            booleanMetaField.CreationDate = now;
            booleanMetaField.CreationUser = user;
            booleanMetaField.LastUpdateDate = now;
            booleanMetaField.LastUpdateUser = user;
            return booleanMetaField;
        }

        public IDateTimeMetaField InitializeDateTimeMetaFieldTemplate(IMetaEntity metaMetaField)
        {
            var dateTimeMetaField = ModelFactory.CreateDateTimeMetaField();
            EntityService.SetEntityDefaultValues(dateTimeMetaField, metaMetaField);
            var now = DateTime.Now;
            var user = MetaModelRepository.GetMdUser(DEFAULT_USER_LOGIN);
            dateTimeMetaField.CreationDate = now;
            dateTimeMetaField.CreationUser = user;
            dateTimeMetaField.LastUpdateDate = now;
            dateTimeMetaField.LastUpdateUser = user;
            return dateTimeMetaField;
        }

        public IDecimalMetaField InitializeDecimalMetaFieldTemplate(IMetaEntity metaMetaField)
        {
            var decimalMetaField = ModelFactory.CreateDecimalMetaField();
            EntityService.SetEntityDefaultValues(decimalMetaField, metaMetaField);
            var now = DateTime.Now;
            var user = MetaModelRepository.GetMdUser(DEFAULT_USER_LOGIN);
            decimalMetaField.CreationDate = now;
            decimalMetaField.CreationUser = user;
            decimalMetaField.LastUpdateDate = now;
            decimalMetaField.LastUpdateUser = user;
            return decimalMetaField;
        }

        public IEntityMetaField InitializeEntityMetaFieldTemplate(IMetaEntity metaMetaField)
        {
            var entityMetaField = ModelFactory.CreateEntityMetaField();
            EntityService.SetEntityDefaultValues(entityMetaField, metaMetaField);
            var now = DateTime.Now;
            var user = MetaModelRepository.GetMdUser(DEFAULT_USER_LOGIN);
            entityMetaField.CreationDate = now;
            entityMetaField.CreationUser = user;
            entityMetaField.LastUpdateDate = now;
            entityMetaField.LastUpdateUser = user;
            return entityMetaField;
        }

        public IIntegerMetaField InitializeIntegerMetaFieldTemplate(IMetaEntity metaMetaField)
        {
            var integerMetaField = ModelFactory.CreateIntegerMetaField();
            EntityService.SetEntityDefaultValues(integerMetaField, metaMetaField);
            var now = DateTime.Now;
            var user = MetaModelRepository.GetMdUser(DEFAULT_USER_LOGIN);
            integerMetaField.CreationDate = now;
            integerMetaField.CreationUser = user;
            integerMetaField.LastUpdateDate = now;
            integerMetaField.LastUpdateUser = user;
            return integerMetaField;
        }

        public IStringMetaField InitializeStringMetaFieldTemplate(IMetaEntity metaMetaField)
        {
            var stringMetaField = ModelFactory.CreateStringMetaField();
            EntityService.SetEntityDefaultValues(stringMetaField, metaMetaField);
            var now = DateTime.Now;
            var user = MetaModelRepository.GetMdUser(DEFAULT_USER_LOGIN);
            stringMetaField.CreationDate = now;
            stringMetaField.CreationUser = user;
            stringMetaField.LastUpdateDate = now;
            stringMetaField.LastUpdateUser = user;
            return stringMetaField;
        }

        public IList<ValueCheckingResult> SaveMetaEntity(IEntityValidator entityValidator, IMetaEntity metaEntity)
        {
            var results = EntityService.CheckEntity(entityValidator, metaEntity);

            if (results.All(r => r.IsValid))
            {
                var user = MetaModelRepository.GetMdUser(DEFAULT_USER_LOGIN);
                var now = DateTime.Now;
                metaEntity.LastUpdateDate = now;
                metaEntity.LastUpdateUser = user;
                if (EntityService.IsEntityNew(metaEntity))
                {
                    metaEntity.CreationDate = now;
                    metaEntity.CreationUser = user;
                    MetaModelRepository.CreateMetaEntity(metaEntity);
                }
                else
                {
                    MetaModelRepository.UpdateMetaEntity(metaEntity);
                }
            }
            return results;
        }

        public IList<ValueCheckingResult> SaveMetaField(IEntityValidator entityValidator, IMetaField metaField)
        {
            var results = EntityService.CheckEntity(entityValidator, metaField);

            if (results.All(r => r.IsValid))
            {
                var user = MetaModelRepository.GetMdUser(DEFAULT_USER_LOGIN);
                var now = DateTime.Now;
                metaField.LastUpdateDate = now;
                metaField.LastUpdateUser = user;
                if (EntityService.IsEntityNew(metaField))
                {
                    metaField.CreationDate = now;
                    metaField.CreationUser = user;
                    MetaModelRepository.CreateMetaField(metaField);
                }
                else
                {
                    MetaModelRepository.UpdateMetaField(metaField);
                }
            }

            return results;
        }

        public IList<ValueCheckingResult> SaveRegularExpression(IEntityValidator entityValidator,
            IRegularExpression regularExpression)
        {
            var results = EntityService.CheckEntity(entityValidator, regularExpression);

            if (results.All(r => r.IsValid))
            {
                var user = MetaModelRepository.GetMdUser(DEFAULT_USER_LOGIN);
                var now = DateTime.Now;
                regularExpression.LastUpdateDate = now;
                regularExpression.LastUpdateUser = user;
                if (EntityService.IsEntityNew(regularExpression))
                {
                    regularExpression.CreationDate = now;
                    regularExpression.CreationUser = user;
                    MetaModelRepository.CreateRegularExpression(regularExpression);
                }
                else
                {
                    MetaModelRepository.UpdateRegularExpression(regularExpression);
                }
            }
            return results;
        }
        #endregion
    }
}