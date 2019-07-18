using Sqi.Framework.Models;
using System.Collections.Generic;

namespace Sqi.MdManager.Services
{
    public interface IMetaDataService
    {
        IList<IMetaEntity> GetMetaEntities();
        IList<IMetaField> GetMetaFieldTemplates();
        IList<IRegularExpression> GetRegularExpressions();
        IBooleanMetaField InitializeBooleanMetaField(IMetaEntity metaMetaField, IMetaEntity metaEntity);
        IDateTimeMetaField InitializeDateTimeMetaField(IMetaEntity metaMetaField, IMetaEntity metaEntity);
        IDecimalMetaField InitializeDecimalMetaField(IMetaEntity metaMetaField, IMetaEntity metaEntity);
        IEntityMetaField InitializeEntityMetaField(IMetaEntity metaMetaField, IMetaEntity metaEntity);
        IIntegerMetaField InitializeIntegerMetaField(IMetaEntity metaMetaField, IMetaEntity metaEntity);
        IMetaEntity InitializeMetaEntity(IMetaEntity metaMetaEntity);
        IRegularExpression InitializeRegularExpression(IMetaEntity metaEntity);
        IStringMetaField InitializeStringMetaField(IMetaEntity metaMetaField, IMetaEntity metaEntity);

        IBooleanMetaField InitializeBooleanMetaFieldTemplate(IMetaEntity metaMetaField);
        IDateTimeMetaField InitializeDateTimeMetaFieldTemplate(IMetaEntity metaMetaField);
        IDecimalMetaField InitializeDecimalMetaFieldTemplate(IMetaEntity metaMetaField);
        IEntityMetaField InitializeEntityMetaFieldTemplate(IMetaEntity metaMetaField);
        IIntegerMetaField InitializeIntegerMetaFieldTemplate(IMetaEntity metaMetaField);
        IStringMetaField InitializeStringMetaFieldTemplate(IMetaEntity metaMetaField);

        IList<ValueCheckingResult> SaveMetaEntity(IEntityValidator entityValidator, IMetaEntity metaEntity);
        IList<ValueCheckingResult> SaveMetaField(IEntityValidator entityValidator, IMetaField metaField);

        IList<ValueCheckingResult> SaveRegularExpression(IEntityValidator entityValidator,
            IRegularExpression regularExpression);
    }
}