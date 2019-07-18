using Sqi.Framework.DataAccess;
using Sqi.Framework.DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlTypes;
using System.Linq;

namespace Sqi.MdManager.DataInitializer
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class Program
    {
        #region Methods

        private static Dictionary<int, MetaField> Templatedictionary = new Dictionary<int, MetaField>();
        public static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Réinitialisation des données...");
                Database.SetInitializer(new Init());
                Database.SetInitializer(new CreateDatabaseIfNotExists<FrameworkModelContext>());
                Database.SetInitializer(new DropCreateDatabaseAlways<FrameworkModelContext>());
                CreateData();
                Console.WriteLine("Réinitialisation terminée.");
                Console.Read();
            }
            catch (Exception exception)
            {
                Console.WriteLine();
                Console.WriteLine(exception);
                Console.Read();
            }
        }

        private static MetaEntity BuildMetaBooleanMetaField(RegularExpression technicalNameRegularExpression,
            MetaEntity metaMetaEntity, MetaEntity metaUser,
            MdUser user, DateTime now) => new MetaEntity
            {
                InterfaceName = "IBooleanMetaField",
                Label = "Méta-champ booléen",
                PlurialLabel = "Méta-champs booléen",
                IsMasculine = true,
                Description = null,
                CreationUserId = user.Id,
                CreationDate = now,
                LastUpdateUserId = user.Id,
                LastUpdateDate = now,
                MetaFields = new List<MetaField>
            {
                new MetaField
                {
                    FieldName = "Id",
                    Label = "Identifiant",
                    Description = "Identifiant du champ.",
                    IsRequired = true,
                    IsReadOnly = true,
                    IsVisible = false,
                    IsResetOnCopy = true,
                    StringFormat = null,
                    CreationUserId = user.Id,
                    CreationDate = now,
                    LastUpdateUserId = user.Id,
                    LastUpdateDate = now,
                    IntegerMetaField = new IntegerMetaField
                    {
                        MaxValue = null,
                        MinValue = 0,
                        DefaultValue = null
                    }
                },
                new MetaField
                {
                    FieldName = "MetaEntity",
                    Label = "Méta-entité",
                    Description = "Méta-entité du champ.",
                    IsRequired = true,
                    IsReadOnly = true,
                    IsVisible = true,
                    IsResetOnCopy = false,
                    CreationUserId = user.Id,
                    LastUpdateUserId = user.Id,
                    CreationDate = now,
                    LastUpdateDate = now,
                    StringFormat = null,
                    EntityMetaField = new EntityMetaField
                    {
                        ValueTypeId = metaMetaEntity.Id
                    }
                },
                new MetaField
                {
                    FieldName = "FieldName",
                    Label = "Nom",
                    Description = "Nom technique du champ.",
                    IsRequired = true,
                    IsReadOnly = false,
                    IsVisible = true,
                    IsResetOnCopy = true,
                    CreationUserId = user.Id,
                    LastUpdateUserId = user.Id,
                    CreationDate = now,
                    LastUpdateDate = now,
                    StringFormat = null,
                    StringMetaField = new StringMetaField
                    {
                        MinLength = null,
                        MaxLength = 128,
                        DisplayedLinesCount = 1,
                        DefaultValue = null,
                        RegularExpressionId = technicalNameRegularExpression.Id
                    }
                },
                new MetaField
                {
                    FieldName = "Label",
                    Label = "Libellé",
                    Description = "Libellé du champ.",
                    IsRequired = true,
                    IsReadOnly = false,
                    IsVisible = true,
                    IsResetOnCopy = false,
                    CreationUserId = user.Id,
                    LastUpdateUserId = user.Id,
                    CreationDate = now,
                    LastUpdateDate = now,
                    StringFormat = null,
                    StringMetaField = new StringMetaField
                    {
                        MinLength = null,
                        MaxLength = 128,
                        DisplayedLinesCount = 1,
                        DefaultValue = null,
                        RegularExpressionId = null
                    }
                },
                new MetaField
                {
                    FieldName = "Description",
                    Label = "Description",
                    Description = "Description du champ.",
                    IsRequired = false,
                    IsReadOnly = false,
                    IsVisible = true,
                    IsResetOnCopy = false,
                    CreationUserId = user.Id,
                    LastUpdateUserId = user.Id,
                    CreationDate = now,
                    LastUpdateDate = now,
                    StringFormat = null,
                    StringMetaField = new StringMetaField
                    {
                        MinLength = null,
                        MaxLength = 1024,
                        DisplayedLinesCount = 3,
                        DefaultValue = null,
                        RegularExpressionId = null
                    }
                },
                new MetaField
                {
                    FieldName = "IsRequired",
                    Label = "Requis",
                    Description = "Le champ est requis.",
                    IsRequired = true,
                    IsReadOnly = false,
                    IsVisible = true,
                    IsResetOnCopy = false,
                    CreationUserId = user.Id,
                    LastUpdateUserId = user.Id,
                    CreationDate = now,
                    LastUpdateDate = now,
                    StringFormat = null,
                    BooleanMetaField = new BooleanMetaField
                    {
                        DefaultValue = null
                    }
                },
                new MetaField
                {
                    FieldName = "IsReadOnly",
                    Label = "Lecture seule",
                    Description = "Le champ est en lecture seule.",
                    IsRequired = true,
                    IsReadOnly = false,
                    IsVisible = true,
                    IsResetOnCopy = false,
                    CreationUserId = user.Id,
                    LastUpdateUserId = user.Id,
                    CreationDate = now,
                    LastUpdateDate = now,
                    StringFormat = null,
                    BooleanMetaField = new BooleanMetaField
                    {
                        DefaultValue = null
                    }
                },
                new MetaField
                {
                    FieldName = "IsVisible",
                    Label = "Visible",
                    Description = "Le champ est visible dans les formulaires.",
                    IsRequired = true,
                    IsReadOnly = false,
                    IsVisible = true,
                    IsResetOnCopy = false,
                    CreationUserId = user.Id,
                    LastUpdateUserId = user.Id,
                    CreationDate = now,
                    LastUpdateDate = now,
                    StringFormat = null,
                    BooleanMetaField = new BooleanMetaField
                    {
                        DefaultValue = null
                    }
                },
                new MetaField
                {
                    FieldName = "IsResetOnCopy",
                    Label = "RaZ sur copie",
                    Description = "Le champ est remis à zéro lorsqu'il est copié.",
                    IsRequired = true,
                    IsReadOnly = false,
                    IsVisible = true,
                    IsResetOnCopy = false,
                    CreationUserId = user.Id,
                    LastUpdateUserId = user.Id,
                    CreationDate = now,
                    LastUpdateDate = now,
                    StringFormat = null,
                    BooleanMetaField = new BooleanMetaField
                    {
                        DefaultValue = null
                    }
                },
                new MetaField
                {
                    FieldName = "StringFormat",
                    Label = "Format de chaîne",
                    Description = "Format de la chaîne de caractère désignant la valeur du champ.",
                    IsRequired = false,
                    IsReadOnly = false,
                    IsVisible = true,
                    IsResetOnCopy = false,
                    CreationUserId = user.Id,
                    LastUpdateUserId = user.Id,
                    CreationDate = now,
                    LastUpdateDate = now,
                    StringFormat = null,
                    StringMetaField = new StringMetaField
                    {
                        MinLength = null,
                        MaxLength = 128,
                        DisplayedLinesCount = 1,
                        DefaultValue = null,
                        RegularExpressionId = null
                    }
                },
                new MetaField
                {
                    FieldName = "CreationDate",
                    Label = "Date création",
                    Description = "Date de création du méta-champ.",
                    IsRequired = true,
                    IsReadOnly = true,
                    IsVisible = false,
                    IsResetOnCopy = true,
                    CreationUserId = user.Id,
                    LastUpdateUserId = user.Id,
                    CreationDate = now,
                    LastUpdateDate = now,
                    StringFormat = "d",
                    DateTimeMetaField = new DateTimeMetaField
                    {
                        MinValue = now.Date,
                        MaxValue = null,
                        IsDefaultValueNow = true,
                        DefaultValue = null
                    }
                },
                new MetaField
                {
                    FieldName = "CreationUser",
                    Label = "Utilisateur création",
                    Description = "Utilisateur ayant créé le méta-champ.",
                    IsRequired = true,
                    IsReadOnly = true,
                    IsVisible = false,
                    IsResetOnCopy = true,
                    CreationUserId = user.Id,
                    LastUpdateUserId = user.Id,
                    CreationDate = now,
                    LastUpdateDate = now,
                    StringFormat = null,
                    EntityMetaField = new EntityMetaField
                    {
                        ValueTypeId = metaUser.Id,
                        DefaultValueId = null
                    }
                },
                new MetaField
                {
                    FieldName = "LastUpdateDate",
                    Label = "Date mise à jour",
                    Description = "Date de dernière mise à jour du méta-champ.",
                    IsRequired = true,
                    IsReadOnly = true,
                    IsVisible = false,
                    IsResetOnCopy = true,
                    CreationUserId = user.Id,
                    LastUpdateUserId = user.Id,
                    CreationDate = now,
                    LastUpdateDate = now,
                    StringFormat = "d",
                    DateTimeMetaField = new DateTimeMetaField
                    {
                        MinValue = now.Date,
                        MaxValue = null,
                        IsDefaultValueNow = true,
                        DefaultValue = null
                    }
                },
                new MetaField
                {
                    FieldName = "LastUpdateUser",
                    Label = "Utilisateur mise à jour",
                    Description = "Utilisateur ayant réalisé la dernière mise à jour du méta-champ.",
                    IsRequired = true,
                    IsReadOnly = true,
                    IsVisible = false,
                    IsResetOnCopy = true,
                    CreationUserId = user.Id,
                    LastUpdateUserId = user.Id,
                    CreationDate = now,
                    LastUpdateDate = now,
                    StringFormat = null,
                    EntityMetaField = new EntityMetaField
                    {
                        ValueTypeId = metaUser.Id,
                        DefaultValueId = null
                    }
                },
                new MetaField
                {
                    FieldName = "DefaultValue",
                    Label = "Valeur défaut",
                    Description = "Valeur par défaut du champ.",
                    IsRequired = false,
                    IsReadOnly = false,
                    IsVisible = true,
                    IsResetOnCopy = false,
                    CreationUserId = user.Id,
                    LastUpdateUserId = user.Id,
                    CreationDate = now,
                    LastUpdateDate = now,
                    StringFormat = null,
                    BooleanMetaField = new BooleanMetaField
                    {
                        DefaultValue = null
                    }
                }
            }
            };

        private static MetaEntity BuildMetaDateTimeMetaField(RegularExpression technicalNameRegularExpression,
            MetaEntity metaMetaEntity, MetaEntity metaUser,
            MdUser user, DateTime now) => new MetaEntity
            {
                InterfaceName = "IDateTimeMetaField",
                Label = "Méta-champ date",
                PlurialLabel = "Méta-champs date",
                IsMasculine = true,
                Description = null,
                CreationUserId = user.Id,
                CreationDate = now,
                LastUpdateUserId = user.Id,
                LastUpdateDate = now,
                MetaFields = new List<MetaField>
            {
                new MetaField
                {
                    FieldName = "Id",
                    Label = "Identifiant",
                    Description = "Identifiant du champ.",
                    IsRequired = true,
                    IsReadOnly = true,
                    IsVisible = false,
                    IsResetOnCopy = true,
                    StringFormat = null,
                    CreationUserId = user.Id,
                    CreationDate = now,
                    LastUpdateUserId = user.Id,
                    LastUpdateDate = now,
                    IntegerMetaField = new IntegerMetaField
                    {
                        MaxValue = null,
                        MinValue = 0,
                        DefaultValue = null
                    }
                },
                new MetaField
                {
                    FieldName = "MetaEntity",
                    Label = "Méta-entité",
                    Description = "Méta-entité du champ.",
                    IsRequired = true,
                    IsReadOnly = true,
                    IsVisible = true,
                    IsResetOnCopy = false,
                    StringFormat = null,
                    CreationUserId = user.Id,
                    CreationDate = now,
                    LastUpdateUserId = user.Id,
                    LastUpdateDate = now,
                    EntityMetaField = new EntityMetaField
                    {
                        ValueTypeId = metaMetaEntity.Id
                    }
                },
                new MetaField
                {
                    FieldName = "FieldName",
                    Label = "Nom",
                    Description = "Nom technique du champ.",
                    IsRequired = true,
                    IsReadOnly = false,
                    IsVisible = true,
                    IsResetOnCopy = true,
                    StringFormat = null,
                    CreationUserId = user.Id,
                    CreationDate = now,
                    LastUpdateUserId = user.Id,
                    LastUpdateDate = now,
                    StringMetaField = new StringMetaField
                    {
                        MinLength = null,
                        MaxLength = 128,
                        DisplayedLinesCount = 1,
                        DefaultValue = null,
                        RegularExpressionId = technicalNameRegularExpression.Id
                    }
                },
                new MetaField
                {
                    FieldName = "Label",
                    Label = "Libellé",
                    Description = "Libellé du champ.",
                    IsRequired = true,
                    IsReadOnly = false,
                    IsVisible = true,
                    IsResetOnCopy = false,
                    StringFormat = null,
                    CreationUserId = user.Id,
                    CreationDate = now,
                    LastUpdateUserId = user.Id,
                    LastUpdateDate = now,
                    StringMetaField = new StringMetaField
                    {
                        MinLength = null,
                        MaxLength = 128,
                        DisplayedLinesCount = 1,
                        DefaultValue = null,
                        RegularExpressionId = null
                    }
                },
                new MetaField
                {
                    FieldName = "Description",
                    Label = "Description",
                    Description = "Description du champ.",
                    IsRequired = false,
                    IsReadOnly = false,
                    IsVisible = true,
                    IsResetOnCopy = false,
                    StringFormat = null,
                    CreationUserId = user.Id,
                    CreationDate = now,
                    LastUpdateUserId = user.Id,
                    LastUpdateDate = now,
                    StringMetaField = new StringMetaField
                    {
                        MinLength = null,
                        MaxLength = 1024,
                        DisplayedLinesCount = 3,
                        DefaultValue = null,
                        RegularExpressionId = null
                    }
                },
                new MetaField
                {
                    FieldName = "IsRequired",
                    Label = "Requis",
                    Description = "Le champ est requis.",
                    IsRequired = true,
                    IsReadOnly = false,
                    IsVisible = true,
                    IsResetOnCopy = false,
                    StringFormat = null,
                    CreationUserId = user.Id,
                    CreationDate = now,
                    LastUpdateUserId = user.Id,
                    LastUpdateDate = now,
                    BooleanMetaField = new BooleanMetaField
                    {
                        DefaultValue = null
                    }
                },
                new MetaField
                {
                    FieldName = "IsReadOnly",
                    Label = "Lecture seule",
                    Description = "Le champ est en lecture seule.",
                    IsRequired = true,
                    IsReadOnly = false,
                    IsVisible = true,
                    IsResetOnCopy = false,
                    StringFormat = null,
                    CreationUserId = user.Id,
                    CreationDate = now,
                    LastUpdateUserId = user.Id,
                    LastUpdateDate = now,
                    BooleanMetaField = new BooleanMetaField
                    {
                        DefaultValue = null
                    }
                },
                new MetaField
                {
                    FieldName = "IsVisible",
                    Label = "Visible",
                    Description = "Le champ est visible dans les formulaires.",
                    IsRequired = true,
                    IsReadOnly = false,
                    IsVisible = true,
                    IsResetOnCopy = false,
                    CreationUserId = user.Id,
                    LastUpdateUserId = user.Id,
                    CreationDate = now,
                    LastUpdateDate = now,
                    StringFormat = null,
                    BooleanMetaField = new BooleanMetaField
                    {
                        DefaultValue = null
                    }
                },
                new MetaField
                {
                    FieldName = "IsResetOnCopy",
                    Label = "RaZ sur copie",
                    Description = "Le champ est remis à zéro lorsqu'il est copié.",
                    IsRequired = true,
                    IsReadOnly = false,
                    IsVisible = true,
                    IsResetOnCopy = false,
                    StringFormat = null,
                    CreationUserId = user.Id,
                    CreationDate = now,
                    LastUpdateUserId = user.Id,
                    LastUpdateDate = now,
                    BooleanMetaField = new BooleanMetaField
                    {
                        DefaultValue = null
                    }
                },
                new MetaField
                {
                    FieldName = "StringFormat",
                    Label = "Format de chaîne",
                    Description = "Format de la chaîne de caractère désignant la valeur du champ.",
                    IsRequired = false,
                    IsReadOnly = false,
                    IsVisible = true,
                    IsResetOnCopy = false,
                    StringFormat = null,
                    CreationUserId = user.Id,
                    CreationDate = now,
                    LastUpdateUserId = user.Id,
                    LastUpdateDate = now,
                    StringMetaField = new StringMetaField
                    {
                        MinLength = null,
                        MaxLength = 128,
                        DisplayedLinesCount = 1,
                        DefaultValue = null
                    }
                },
                new MetaField
                {
                    FieldName = "CreationDate",
                    Label = "Date création",
                    Description = "Date de création du méta-champ.",
                    IsRequired = true,
                    IsReadOnly = true,
                    IsVisible = false,
                    IsResetOnCopy = true,
                    StringFormat = "d",
                    CreationUserId = user.Id,
                    CreationDate = now,
                    LastUpdateUserId = user.Id,
                    LastUpdateDate = now,
                    DateTimeMetaField = new DateTimeMetaField
                    {
                        MinValue = now.Date,
                        MaxValue = null,
                        IsDefaultValueNow = true,
                        DefaultValue = null
                    }
                },
                new MetaField
                {
                    FieldName = "CreationUser",
                    Label = "Utilisateur création",
                    Description = "Utilisateur ayant créé le méta-champ.",
                    IsRequired = true,
                    IsReadOnly = true,
                    IsVisible = false,
                    IsResetOnCopy = true,
                    StringFormat = null,
                    CreationUserId = user.Id,
                    CreationDate = now,
                    LastUpdateUserId = user.Id,
                    LastUpdateDate = now,
                    EntityMetaField = new EntityMetaField
                    {
                        ValueTypeId = metaUser.Id,
                        DefaultValueId = null
                    }
                },
                new MetaField
                {
                    FieldName = "LastUpdateDate",
                    Label = "Date mise à jour",
                    Description = "Date de dernière mise à jour du méta-champ.",
                    IsRequired = true,
                    IsReadOnly = true,
                    IsVisible = false,
                    IsResetOnCopy = true,
                    StringFormat = "d",
                    CreationUserId = user.Id,
                    CreationDate = now,
                    LastUpdateUserId = user.Id,
                    LastUpdateDate = now,
                    DateTimeMetaField = new DateTimeMetaField
                    {
                        MinValue = now.Date,
                        MaxValue = null,
                        IsDefaultValueNow = true,
                        DefaultValue = null
                    }
                },
                new MetaField
                {
                    FieldName = "LastUpdateUser",
                    Label = "Utilisateur mise à jour",
                    Description = "Utilisateur ayant réalisé la dernière mise à jour du méta-champ.",
                    IsRequired = true,
                    IsReadOnly = true,
                    IsVisible = false,
                    IsResetOnCopy = true,
                    StringFormat = null,
                    CreationUserId = user.Id,
                    CreationDate = now,
                    LastUpdateUserId = user.Id,
                    LastUpdateDate = now,
                    EntityMetaField = new EntityMetaField
                    {
                        ValueTypeId = metaUser.Id,
                        DefaultValueId = null
                    }
                },
                new MetaField
                {
                    FieldName = "MinValue",
                    Label = "Valeur min.",
                    Description = "Valeur minimale de la date.",
                    IsRequired = false,
                    IsReadOnly = false,
                    IsVisible = true,
                    IsResetOnCopy = false,
                    StringFormat = null,
                    CreationUserId = user.Id,
                    CreationDate = now,
                    LastUpdateUserId = user.Id,
                    LastUpdateDate = now,
                    DateTimeMetaField = new DateTimeMetaField
                    {
                        MinValue = (DateTime) SqlDateTime.MinValue,
                        MaxValue = null,
                        IsDefaultValueNow = false,
                        DefaultValue = (DateTime) SqlDateTime.MinValue
                    }
                },
                new MetaField
                {
                    FieldName = "MaxValue",
                    Label = "Valeur max.",
                    Description = "Valeur maximale de la date.",
                    IsRequired = false,
                    IsReadOnly = false,
                    IsVisible = true,
                    IsResetOnCopy = false,
                    StringFormat = null,
                    CreationUserId = user.Id,
                    CreationDate = now,
                    LastUpdateUserId = user.Id,
                    LastUpdateDate = now,
                    DateTimeMetaField = new DateTimeMetaField
                    {
                        MinValue = (DateTime) SqlDateTime.MinValue,
                        MaxValue = null,
                        IsDefaultValueNow = false,
                        DefaultValue = DateTime.MaxValue
                    }
                },
                new MetaField
                {
                    FieldName = "IsDefaultValueNow",
                    Label = "Maintenant par déf.",
                    Description = "La valeur par défaut est maintenant.",
                    IsRequired = true,
                    IsReadOnly = false,
                    IsVisible = true,
                    IsResetOnCopy = false,
                    StringFormat = null,
                    CreationUserId = user.Id,
                    CreationDate = now,
                    LastUpdateUserId = user.Id,
                    LastUpdateDate = now,
                    BooleanMetaField = new BooleanMetaField
                    {
                        DefaultValue = null
                    }
                },
                new MetaField
                {
                    FieldName = "DefaultValue",
                    Label = "Valeur défaut",
                    Description = "Valeur par défaut du champ.",
                    IsRequired = false,
                    IsReadOnly = false,
                    IsVisible = true,
                    IsResetOnCopy = false,
                    StringFormat = null,
                    CreationUserId = user.Id,
                    CreationDate = now,
                    LastUpdateUserId = user.Id,
                    LastUpdateDate = now,
                    DateTimeMetaField = new DateTimeMetaField
                    {
                        MinValue = (DateTime) SqlDateTime.MinValue,
                        MaxValue = null,
                        IsDefaultValueNow = false,
                        DefaultValue = null
                    }
                }
            }
            };

        private static MetaEntity BuildMetaDecimalMetaField(RegularExpression technicalNameRegularExpression,
            MetaEntity metaMetaEntity, MetaEntity metaUser, MdUser user, DateTime now) => new MetaEntity
            {
                InterfaceName = "IDecimalMetaField",
                Label = "Méta-champ décimale",
                PlurialLabel = "Méta-champs décimale",
                IsMasculine = true,
                Description = null,
                CreationUserId = user.Id,
                CreationDate = now,
                LastUpdateUserId = user.Id,
                LastUpdateDate = now,
                MetaFields = new List<MetaField>
            {
                new MetaField
                {
                    FieldName = "Id",
                    Label = "Identifiant",
                    Description = "Identifiant du champ.",
                    IsRequired = true,
                    IsReadOnly = true,
                    IsVisible = false,
                    IsResetOnCopy = true,
                    StringFormat = null,
                    CreationUserId = user.Id,
                    CreationDate = now,
                    LastUpdateUserId = user.Id,
                    LastUpdateDate = now,
                    IntegerMetaField = new IntegerMetaField
                    {
                        MaxValue = null,
                        MinValue = 0,
                        DefaultValue = null
                    }
                },
                new MetaField
                {
                    FieldName = "MetaEntity",
                    Label = "Méta-entité",
                    Description = "Méta-entité du champ.",
                    IsRequired = true,
                    IsReadOnly = true,
                    IsVisible = true,
                    IsResetOnCopy = false,
                    StringFormat = null,
                    CreationUserId = user.Id,
                    CreationDate = now,
                    LastUpdateUserId = user.Id,
                    LastUpdateDate = now,
                    EntityMetaField = new EntityMetaField
                    {
                        ValueTypeId = metaMetaEntity.Id
                    }
                },
                new MetaField
                {
                    FieldName = "FieldName",
                    Label = "Nom",
                    Description = "Nom technique du champ.",
                    IsRequired = true,
                    IsReadOnly = false,
                    IsVisible = true,
                    IsResetOnCopy = true,
                    StringFormat = null,
                    CreationUserId = user.Id,
                    CreationDate = now,
                    LastUpdateUserId = user.Id,
                    LastUpdateDate = now,
                    StringMetaField = new StringMetaField
                    {
                        MinLength = null,
                        MaxLength = 128,
                        DisplayedLinesCount = 1,
                        DefaultValue = null,
                        RegularExpressionId = technicalNameRegularExpression.Id
                    }
                },
                new MetaField
                {
                    FieldName = "Label",
                    Label = "Libellé",
                    Description = "Libellé du champ.",
                    IsRequired = true,
                    IsReadOnly = false,
                    IsVisible = true,
                    IsResetOnCopy = false,
                    StringFormat = null,
                    CreationUserId = user.Id,
                    CreationDate = now,
                    LastUpdateUserId = user.Id,
                    LastUpdateDate = now,
                    StringMetaField = new StringMetaField
                    {
                        MinLength = null,
                        MaxLength = 128,
                        DisplayedLinesCount = 1,
                        DefaultValue = null,
                        RegularExpressionId = null
                    }
                },
                new MetaField
                {
                    FieldName = "Description",
                    Label = "Description",
                    Description = "Description du champ.",
                    IsRequired = false,
                    IsReadOnly = false,
                    IsVisible = true,
                    IsResetOnCopy = false,
                    StringFormat = null,
                    CreationUserId = user.Id,
                    CreationDate = now,
                    LastUpdateUserId = user.Id,
                    LastUpdateDate = now,
                    StringMetaField = new StringMetaField
                    {
                        MinLength = null,
                        MaxLength = 1024,
                        DisplayedLinesCount = 3,
                        DefaultValue = null,
                        RegularExpressionId = null
                    }
                },
                new MetaField
                {
                    FieldName = "IsRequired",
                    Label = "Requis",
                    Description = "Le champ est requis.",
                    IsRequired = true,
                    IsReadOnly = false,
                    IsVisible = true,
                    IsResetOnCopy = false,
                    StringFormat = null,
                    CreationUserId = user.Id,
                    CreationDate = now,
                    LastUpdateUserId = user.Id,
                    LastUpdateDate = now,
                    BooleanMetaField = new BooleanMetaField
                    {
                        DefaultValue = null
                    }
                },
                new MetaField
                {
                    FieldName = "IsReadOnly",
                    Label = "Lecture seule",
                    Description = "Le champ est en lecture seule.",
                    IsRequired = true,
                    IsReadOnly = false,
                    IsVisible = true,
                    IsResetOnCopy = false,
                    StringFormat = null,
                    CreationUserId = user.Id,
                    CreationDate = now,
                    LastUpdateUserId = user.Id,
                    LastUpdateDate = now,
                    BooleanMetaField = new BooleanMetaField
                    {
                        DefaultValue = null
                    }
                },
                new MetaField
                {
                    FieldName = "IsVisible",
                    Label = "Visible",
                    Description = "Le champ est visible dans les formulaires.",
                    IsRequired = true,
                    IsReadOnly = false,
                    IsVisible = true,
                    IsResetOnCopy = false,
                    CreationUserId = user.Id,
                    LastUpdateUserId = user.Id,
                    CreationDate = now,
                    LastUpdateDate = now,
                    StringFormat = null,
                    BooleanMetaField = new BooleanMetaField
                    {
                        DefaultValue = null
                    }
                },
                new MetaField
                {
                    FieldName = "IsResetOnCopy",
                    Label = "RaZ sur copie",
                    Description = "Le champ est remis à zéro lorsqu'il est copié.",
                    IsRequired = true,
                    IsReadOnly = false,
                    IsVisible = true,
                    IsResetOnCopy = false,
                    StringFormat = null,
                    CreationUserId = user.Id,
                    CreationDate = now,
                    LastUpdateUserId = user.Id,
                    LastUpdateDate = now,
                    BooleanMetaField = new BooleanMetaField
                    {
                        DefaultValue = null
                    }
                },
                new MetaField
                {
                    FieldName = "StringFormat",
                    Label = "Format de chaîne",
                    Description = "Format de la chaîne de caractère désignant la valeur du champ.",
                    IsRequired = false,
                    IsReadOnly = false,
                    IsVisible = true,
                    IsResetOnCopy = false,
                    StringFormat = null,
                    CreationUserId = user.Id,
                    CreationDate = now,
                    LastUpdateUserId = user.Id,
                    LastUpdateDate = now,
                    StringMetaField = new StringMetaField
                    {
                        MinLength = null,
                        MaxLength = 128,
                        DisplayedLinesCount = 1,
                        DefaultValue = null,
                        RegularExpressionId = null
                    }
                },
                new MetaField
                {
                    FieldName = "CreationDate",
                    Label = "Date création",
                    Description = "Date de création du méta-champ.",
                    IsRequired = true,
                    IsReadOnly = true,
                    IsVisible = false,
                    IsResetOnCopy = true,
                    StringFormat = "d",
                    CreationUserId = user.Id,
                    CreationDate = now,
                    LastUpdateUserId = user.Id,
                    LastUpdateDate = now,
                    DateTimeMetaField = new DateTimeMetaField
                    {
                        MinValue = now.Date,
                        MaxValue = null,
                        IsDefaultValueNow = true,
                        DefaultValue = null
                    }
                },
                new MetaField
                {
                    FieldName = "CreationUser",
                    Label = "Utilisateur création",
                    Description = "Utilisateur ayant créé le méta-champ.",
                    IsRequired = true,
                    IsReadOnly = true,
                    IsVisible = false,
                    IsResetOnCopy = true,
                    StringFormat = null,
                    CreationUserId = user.Id,
                    CreationDate = now,
                    LastUpdateUserId = user.Id,
                    LastUpdateDate = now,
                    EntityMetaField = new EntityMetaField
                    {
                        ValueTypeId = metaUser.Id,
                        DefaultValueId = null
                    }
                },
                new MetaField
                {
                    FieldName = "LastUpdateDate",
                    Label = "Date mise à jour",
                    Description = "Date de dernière mise à jour du méta-champ.",
                    IsRequired = true,
                    IsReadOnly = true,
                    IsVisible = false,
                    IsResetOnCopy = true,
                    StringFormat = "d",
                    CreationUserId = user.Id,
                    CreationDate = now,
                    LastUpdateUserId = user.Id,
                    LastUpdateDate = now,
                    DateTimeMetaField = new DateTimeMetaField
                    {
                        MinValue = now.Date,
                        MaxValue = null,
                        IsDefaultValueNow = true,
                        DefaultValue = null
                    }
                },
                new MetaField
                {
                    FieldName = "LastUpdateUser",
                    Label = "Utilisateur mise à jour",
                    Description = "Utilisateur ayant réalisé la dernière mise à jour du méta-champ.",
                    IsRequired = true,
                    IsReadOnly = true,
                    IsVisible = false,
                    IsResetOnCopy = true,
                    StringFormat = null,
                    CreationUserId = user.Id,
                    CreationDate = now,
                    LastUpdateUserId = user.Id,
                    LastUpdateDate = now,
                    EntityMetaField = new EntityMetaField
                    {
                        ValueTypeId = metaUser.Id,
                        DefaultValueId = null
                    }
                },
                new MetaField
                {
                    FieldName = "MinValue",
                    Label = "Valeur min.",
                    Description = "Valeur minimale de la décimale.",
                    IsRequired = false,
                    IsReadOnly = false,
                    IsVisible = true,
                    IsResetOnCopy = false,
                    StringFormat = null,
                    CreationUserId = user.Id,
                    CreationDate = now,
                    LastUpdateUserId = user.Id,
                    LastUpdateDate = now,
                    DecimalMetaField = new DecimalMetaField
                    {
                        MinValue = null,
                        MaxValue = null,
                        Scale = 9,
                        DefaultValue = null
                    }
                },
                new MetaField
                {
                    FieldName = "MaxValue",
                    Label = "Valeur max.",
                    Description = "Valeur maximale de la décimale.",
                    IsRequired = false,
                    IsReadOnly = false,
                    IsVisible = true,
                    IsResetOnCopy = false,
                    StringFormat = null,
                    CreationUserId = user.Id,
                    CreationDate = now,
                    LastUpdateUserId = user.Id,
                    LastUpdateDate = now,
                    DecimalMetaField = new DecimalMetaField
                    {
                        MinValue = null,
                        MaxValue = null,
                        Scale = 9,
                        DefaultValue = null
                    }
                },
                new MetaField
                {
                    FieldName = "Scale",
                    Label = "Échelle",
                    Description = "Nombre de chiffres après la virgule de la décimale.",
                    IsRequired = true,
                    IsReadOnly = false,
                    IsVisible = true,
                    IsResetOnCopy = false,
                    StringFormat = null,
                    CreationUserId = user.Id,
                    CreationDate = now,
                    LastUpdateUserId = user.Id,
                    LastUpdateDate = now,
                    IntegerMetaField = new IntegerMetaField
                    {
                        MinValue = 0,
                        MaxValue = 9,
                        DefaultValue = 2
                    }
                },
                new MetaField
                {
                    FieldName = "DefaultValue",
                    Label = "Valeur défaut",
                    Description = "Valeur par défaut du champ.",
                    IsRequired = false,
                    IsReadOnly = false,
                    IsVisible = true,
                    IsResetOnCopy = false,
                    StringFormat = null,
                    CreationUserId = user.Id,
                    CreationDate = now,
                    LastUpdateUserId = user.Id,
                    LastUpdateDate = now,
                    DecimalMetaField = new DecimalMetaField
                    {
                        MinValue = null,
                        MaxValue = null,
                        Scale = 9,
                        DefaultValue = null
                    }
                }
            }
            };

        private static MetaEntity BuildMetaEntityMetaField(RegularExpression technicalNameRegularExpression,
            MetaEntity metaMetaEntity, MetaEntity metaUser,
            MdUser user, DateTime now) => new MetaEntity
            {
                InterfaceName = "IEntityMetaField",
                Label = "Méta-champ entité",
                PlurialLabel = "Méta-champs entité",
                IsMasculine = true,
                Description = null,
                CreationUserId = user.Id,
                CreationDate = now,
                LastUpdateUserId = user.Id,
                LastUpdateDate = now,
                MetaFields = new List<MetaField>
            {
                new MetaField
                {
                    FieldName = "Id",
                    Label = "Identifiant",
                    Description = "Identifiant du champ.",
                    IsRequired = true,
                    IsReadOnly = true,
                    IsVisible = false,
                    IsResetOnCopy = true,
                    StringFormat = null,
                    CreationUserId = user.Id,
                    CreationDate = now,
                    LastUpdateUserId = user.Id,
                    LastUpdateDate = now,
                    IntegerMetaField = new IntegerMetaField
                    {
                        MaxValue = null,
                        MinValue = 0,
                        DefaultValue = null
                    }
                },
                new MetaField
                {
                    FieldName = "MetaEntity",
                    Label = "Méta-entité",
                    Description = "Méta-entité du champ.",
                    IsRequired = true,
                    IsReadOnly = true,
                    IsVisible = true,
                    IsResetOnCopy = false,
                    StringFormat = null,
                    CreationUserId = user.Id,
                    CreationDate = now,
                    LastUpdateUserId = user.Id,
                    LastUpdateDate = now,
                    EntityMetaField = new EntityMetaField
                    {
                        ValueTypeId = metaMetaEntity.Id
                    }
                },
                new MetaField
                {
                    FieldName = "FieldName",
                    Label = "Nom",
                    Description = "Nom technique du champ.",
                    IsRequired = true,
                    IsReadOnly = false,
                    IsVisible = true,
                    IsResetOnCopy = true,
                    StringFormat = null,
                    CreationUserId = user.Id,
                    CreationDate = now,
                    LastUpdateUserId = user.Id,
                    LastUpdateDate = now,
                    StringMetaField = new StringMetaField
                    {
                        MinLength = null,
                        MaxLength = 128,
                        DisplayedLinesCount = 1,
                        DefaultValue = null,
                        RegularExpressionId = technicalNameRegularExpression.Id
                    }
                },
                new MetaField
                {
                    FieldName = "Label",
                    Label = "Libellé",
                    Description = "Libellé du champ.",
                    IsRequired = true,
                    IsReadOnly = false,
                    IsVisible = true,
                    IsResetOnCopy = false,
                    StringFormat = null,
                    CreationUserId = user.Id,
                    CreationDate = now,
                    LastUpdateUserId = user.Id,
                    LastUpdateDate = now,
                    StringMetaField = new StringMetaField
                    {
                        MinLength = null,
                        MaxLength = 128,
                        DisplayedLinesCount = 1,
                        DefaultValue = null,
                        RegularExpressionId = null
                    }
                },
                new MetaField
                {
                    FieldName = "Description",
                    Label = "Description",
                    Description = "Description du champ.",
                    IsRequired = false,
                    IsReadOnly = false,
                    IsVisible = true,
                    IsResetOnCopy = false,
                    StringFormat = null,
                    CreationUserId = user.Id,
                    CreationDate = now,
                    LastUpdateUserId = user.Id,
                    LastUpdateDate = now,
                    StringMetaField = new StringMetaField
                    {
                        MinLength = null,
                        MaxLength = 1024,
                        DisplayedLinesCount = 3,
                        DefaultValue = null,
                        RegularExpressionId = null
                    }
                },
                new MetaField
                {
                    FieldName = "IsRequired",
                    Label = "Requis",
                    Description = "Le champ est requis.",
                    IsRequired = true,
                    IsReadOnly = false,
                    IsVisible = true,
                    IsResetOnCopy = false,
                    StringFormat = null,
                    CreationUserId = user.Id,
                    CreationDate = now,
                    LastUpdateUserId = user.Id,
                    LastUpdateDate = now,
                    BooleanMetaField = new BooleanMetaField
                    {
                        DefaultValue = null
                    }
                },
                new MetaField
                {
                    FieldName = "IsReadOnly",
                    Label = "Lecture seule",
                    Description = "Le champ est en lecture seule.",
                    IsRequired = true,
                    IsReadOnly = false,
                    IsVisible = true,
                    IsResetOnCopy = false,
                    StringFormat = null,
                    CreationUserId = user.Id,
                    CreationDate = now,
                    LastUpdateUserId = user.Id,
                    LastUpdateDate = now,
                    BooleanMetaField = new BooleanMetaField
                    {
                        DefaultValue = null
                    }
                },
                new MetaField
                {
                    FieldName = "IsVisible",
                    Label = "Visible",
                    Description = "Le champ est visible dans les formulaires.",
                    IsRequired = true,
                    IsReadOnly = false,
                    IsVisible = true,
                    IsResetOnCopy = false,
                    CreationUserId = user.Id,
                    LastUpdateUserId = user.Id,
                    CreationDate = now,
                    LastUpdateDate = now,
                    StringFormat = null,
                    BooleanMetaField = new BooleanMetaField
                    {
                        DefaultValue = null
                    }
                },
                new MetaField
                {
                    FieldName = "IsResetOnCopy",
                    Label = "RaZ sur copie",
                    Description = "Le champ est remis à zéro lorsqu'il est copié.",
                    IsRequired = true,
                    IsReadOnly = false,
                    IsVisible = true,
                    IsResetOnCopy = false,
                    StringFormat = null,
                    CreationUserId = user.Id,
                    CreationDate = now,
                    LastUpdateUserId = user.Id,
                    LastUpdateDate = now,
                    BooleanMetaField = new BooleanMetaField
                    {
                        DefaultValue = null
                    }
                },
                new MetaField
                {
                    FieldName = "StringFormat",
                    Label = "Format de chaîne",
                    Description = "Format de la chaîne de caractère désignant la valeur du champ.",
                    IsRequired = false,
                    IsReadOnly = false,
                    IsVisible = true,
                    IsResetOnCopy = false,
                    StringFormat = null,
                    CreationUserId = user.Id,
                    CreationDate = now,
                    LastUpdateUserId = user.Id,
                    LastUpdateDate = now,
                    StringMetaField = new StringMetaField
                    {
                        MinLength = null,
                        MaxLength = 128,
                        DisplayedLinesCount = 1,
                        DefaultValue = null,
                        RegularExpressionId = null
                    }
                },
                new MetaField
                {
                    FieldName = "CreationDate",
                    Label = "Date création",
                    Description = "Date de création du méta-champ.",
                    IsRequired = true,
                    IsReadOnly = true,
                    IsVisible = false,
                    IsResetOnCopy = true,
                    StringFormat = "d",
                    CreationUserId = user.Id,
                    CreationDate = now,
                    LastUpdateUserId = user.Id,
                    LastUpdateDate = now,
                    DateTimeMetaField = new DateTimeMetaField
                    {
                        MinValue = now.Date,
                        MaxValue = null,
                        IsDefaultValueNow = true,
                        DefaultValue = null
                    }
                },
                new MetaField
                {
                    FieldName = "CreationUser",
                    Label = "Utilisateur création",
                    Description = "Utilisateur ayant créé le méta-champ.",
                    IsRequired = true,
                    IsReadOnly = true,
                    IsVisible = false,
                    IsResetOnCopy = true,
                    StringFormat = null,
                    CreationUserId = user.Id,
                    CreationDate = now,
                    LastUpdateUserId = user.Id,
                    LastUpdateDate = now,
                    EntityMetaField = new EntityMetaField
                    {
                        ValueTypeId = metaUser.Id,
                        DefaultValueId = null
                    }
                },
                new MetaField
                {
                    FieldName = "LastUpdateDate",
                    Label = "Date mise à jour",
                    Description = "Date de dernière mise à jour du méta-champ.",
                    IsRequired = true,
                    IsReadOnly = true,
                    IsVisible = false,
                    IsResetOnCopy = true,
                    StringFormat = "d",
                    CreationUserId = user.Id,
                    CreationDate = now,
                    LastUpdateUserId = user.Id,
                    LastUpdateDate = now,
                    DateTimeMetaField = new DateTimeMetaField
                    {
                        MinValue = now.Date,
                        MaxValue = null,
                        IsDefaultValueNow = true,
                        DefaultValue = null
                    }
                },
                new MetaField
                {
                    FieldName = "LastUpdateUser",
                    Label = "Utilisateur mise à jour",
                    Description = "Utilisateur ayant réalisé la dernière mise à jour du méta-champ.",
                    IsRequired = true,
                    IsReadOnly = true,
                    IsVisible = false,
                    IsResetOnCopy = true,
                    StringFormat = null,
                    CreationUserId = user.Id,
                    CreationDate = now,
                    LastUpdateUserId = user.Id,
                    LastUpdateDate = now,
                    EntityMetaField = new EntityMetaField
                    {
                        ValueTypeId = metaUser.Id,
                        DefaultValueId = null
                    }
                },
                new MetaField
                {
                    FieldName = "ValueType",
                    Label = "Type valeur",
                    Description = "Méta-entité du type de la valeur du champ.",
                    IsRequired = true,
                    IsReadOnly = false,
                    IsVisible = true,
                    IsResetOnCopy = false,
                    StringFormat = null,
                    CreationUserId = user.Id,
                    CreationDate = now,
                    LastUpdateUserId = user.Id,
                    LastUpdateDate = now,
                    EntityMetaField = new EntityMetaField
                    {
                        ValueTypeId = metaMetaEntity.Id,
                        DefaultValueId = null
                    }
                },
                new MetaField
                {
                    FieldName = "DefaultValueId",
                    Label = "ID valeur défaut",
                    Description = "Identifiant de l'entité par défaut sélectionnée.",
                    IsRequired = false,
                    IsReadOnly = false,
                    IsVisible = true,
                    IsResetOnCopy = false,
                    StringFormat = null,
                    CreationUserId = user.Id,
                    CreationDate = now,
                    LastUpdateUserId = user.Id,
                    LastUpdateDate = now,
                    IntegerMetaField = new IntegerMetaField
                    {
                        MaxValue = null,
                        MinValue = 0,
                        DefaultValue = null
                    }
                }
            }
            };

        private static MetaEntity BuildMetaIntegerMetaField(RegularExpression technicalNameRegularExpression,
            MetaEntity metaMetaEntity, MetaEntity metaUser,
            MdUser user, DateTime now) => new MetaEntity
            {
                InterfaceName = "IIntegerMetaField",
                Label = "Méta-champ entier",
                PlurialLabel = "Méta-champs entier",
                IsMasculine = true,
                Description = null,
                CreationUserId = user.Id,
                CreationDate = now,
                LastUpdateUserId = user.Id,
                LastUpdateDate = now,
                MetaFields = new List<MetaField>
            {
                new MetaField
                {
                    FieldName = "Id",
                    Label = "Identifiant",
                    Description = "Identifiant du champ.",
                    IsRequired = true,
                    IsReadOnly = true,
                    IsVisible = false,
                    IsResetOnCopy = true,
                    StringFormat = null,
                    CreationUserId = user.Id,
                    CreationDate = now,
                    LastUpdateUserId = user.Id,
                    LastUpdateDate = now,
                    IntegerMetaField = new IntegerMetaField
                    {
                        MaxValue = null,
                        MinValue = 0,
                        DefaultValue = null
                    }
                },
                new MetaField
                {
                    FieldName = "MetaEntity",
                    Label = "Méta-entité",
                    Description = "Méta-entité du champ.",
                    IsRequired = true,
                    IsReadOnly = true,
                    IsVisible = true,
                    IsResetOnCopy = false,
                    StringFormat = null,
                    CreationUserId = user.Id,
                    CreationDate = now,
                    LastUpdateUserId = user.Id,
                    LastUpdateDate = now,
                    EntityMetaField = new EntityMetaField
                    {
                        ValueTypeId = metaMetaEntity.Id
                    }
                },
                new MetaField
                {
                    FieldName = "FieldName",
                    Label = "Nom",
                    Description = "Nom technique du champ.",
                    IsRequired = true,
                    IsReadOnly = false,
                    IsVisible = true,
                    IsResetOnCopy = true,
                    StringFormat = null,
                    CreationUserId = user.Id,
                    CreationDate = now,
                    LastUpdateUserId = user.Id,
                    LastUpdateDate = now,
                    StringMetaField = new StringMetaField
                    {
                        MinLength = null,
                        MaxLength = 128,
                        DisplayedLinesCount = 1,
                        DefaultValue = null,
                        RegularExpressionId = technicalNameRegularExpression.Id
                    }
                },
                new MetaField
                {
                    FieldName = "Label",
                    Label = "Libellé",
                    Description = "Libellé du champ.",
                    IsRequired = true,
                    IsReadOnly = false,
                    IsVisible = true,
                    IsResetOnCopy = false,
                    StringFormat = null,
                    CreationUserId = user.Id,
                    CreationDate = now,
                    LastUpdateUserId = user.Id,
                    LastUpdateDate = now,
                    StringMetaField = new StringMetaField
                    {
                        MinLength = null,
                        MaxLength = 128,
                        DisplayedLinesCount = 1,
                        DefaultValue = null,
                        RegularExpressionId = null
                    }
                },
                new MetaField
                {
                    FieldName = "Description",
                    Label = "Description",
                    Description = "Description du champ.",
                    IsRequired = false,
                    IsReadOnly = false,
                    IsVisible = true,
                    IsResetOnCopy = false,
                    StringFormat = null,
                    CreationUserId = user.Id,
                    CreationDate = now,
                    LastUpdateUserId = user.Id,
                    LastUpdateDate = now,
                    StringMetaField = new StringMetaField
                    {
                        MinLength = null,
                        MaxLength = 1024,
                        DisplayedLinesCount = 3,
                        DefaultValue = null,
                        RegularExpressionId = null
                    }
                },
                new MetaField
                {
                    FieldName = "IsRequired",
                    Label = "Requis",
                    Description = "Le champ est requis.",
                    IsRequired = true,
                    IsReadOnly = false,
                    IsVisible = true,
                    IsResetOnCopy = false,
                    StringFormat = null,
                    CreationUserId = user.Id,
                    CreationDate = now,
                    LastUpdateUserId = user.Id,
                    LastUpdateDate = now,
                    BooleanMetaField = new BooleanMetaField
                    {
                        DefaultValue = null
                    }
                },
                new MetaField
                {
                    FieldName = "IsReadOnly",
                    Label = "Lecture seule",
                    Description = "Le champ est en lecture seule.",
                    IsRequired = true,
                    IsReadOnly = false,
                    IsVisible = true,
                    IsResetOnCopy = false,
                    StringFormat = null,
                    CreationUserId = user.Id,
                    CreationDate = now,
                    LastUpdateUserId = user.Id,
                    LastUpdateDate = now,
                    BooleanMetaField = new BooleanMetaField
                    {
                        DefaultValue = null
                    }
                },
                new MetaField
                {
                    FieldName = "IsVisible",
                    Label = "Visible",
                    Description = "Le champ est visible dans les formulaires.",
                    IsRequired = true,
                    IsReadOnly = false,
                    IsVisible = true,
                    IsResetOnCopy = false,
                    CreationUserId = user.Id,
                    LastUpdateUserId = user.Id,
                    CreationDate = now,
                    LastUpdateDate = now,
                    StringFormat = null,
                    BooleanMetaField = new BooleanMetaField
                    {
                        DefaultValue = null
                    }
                },
                new MetaField
                {
                    FieldName = "IsResetOnCopy",
                    Label = "RaZ sur copie",
                    Description = "Le champ est remis à zéro lorsqu'il est copié.",
                    IsRequired = true,
                    IsReadOnly = false,
                    IsVisible = true,
                    IsResetOnCopy = false,
                    StringFormat = null,
                    CreationUserId = user.Id,
                    CreationDate = now,
                    LastUpdateUserId = user.Id,
                    LastUpdateDate = now,
                    BooleanMetaField = new BooleanMetaField
                    {
                        DefaultValue = null
                    }
                },
                new MetaField
                {
                    FieldName = "StringFormat",
                    Label = "Format de chaîne",
                    Description = "Format de la chaîne de caractère désignant la valeur du champ.",
                    IsRequired = false,
                    IsReadOnly = false,
                    IsVisible = true,
                    IsResetOnCopy = false,
                    StringFormat = null,
                    CreationUserId = user.Id,
                    CreationDate = now,
                    LastUpdateUserId = user.Id,
                    LastUpdateDate = now,
                    StringMetaField = new StringMetaField
                    {
                        MinLength = null,
                        MaxLength = 128,
                        DisplayedLinesCount = 1,
                        DefaultValue = null,
                        RegularExpressionId = null
                    }
                },
                new MetaField
                {
                    FieldName = "CreationDate",
                    Label = "Date création",
                    Description = "Date de création du méta-champ.",
                    IsRequired = true,
                    IsReadOnly = true,
                    IsVisible = false,
                    IsResetOnCopy = true,
                    StringFormat = "d",
                    CreationUserId = user.Id,
                    CreationDate = now,
                    LastUpdateUserId = user.Id,
                    LastUpdateDate = now,
                    DateTimeMetaField = new DateTimeMetaField
                    {
                        MinValue = now.Date,
                        MaxValue = null,
                        IsDefaultValueNow = true,
                        DefaultValue = null
                    }
                },
                new MetaField
                {
                    FieldName = "CreationUser",
                    Label = "Utilisateur création",
                    Description = "Utilisateur ayant créé le méta-champ.",
                    IsRequired = true,
                    IsReadOnly = true,
                    IsVisible = false,
                    IsResetOnCopy = true,
                    StringFormat = null,
                    CreationUserId = user.Id,
                    CreationDate = now,
                    LastUpdateUserId = user.Id,
                    LastUpdateDate = now,
                    EntityMetaField = new EntityMetaField
                    {
                        ValueTypeId = metaUser.Id,
                        DefaultValueId = null
                    }
                },
                new MetaField
                {
                    FieldName = "LastUpdateDate",
                    Label = "Date mise à jour",
                    Description = "Date de dernière mise à jour du méta-champ.",
                    IsRequired = true,
                    IsReadOnly = true,
                    IsVisible = false,
                    IsResetOnCopy = true,
                    StringFormat = "d",
                    CreationUserId = user.Id,
                    CreationDate = now,
                    LastUpdateUserId = user.Id,
                    LastUpdateDate = now,
                    DateTimeMetaField = new DateTimeMetaField
                    {
                        MinValue = now.Date,
                        MaxValue = null,
                        IsDefaultValueNow = true,
                        DefaultValue = null
                    }
                },
                new MetaField
                {
                    FieldName = "LastUpdateUser",
                    Label = "Utilisateur mise à jour",
                    Description = "Utilisateur ayant réalisé la dernière mise à jour du méta-champ.",
                    IsRequired = true,
                    IsReadOnly = true,
                    IsVisible = false,
                    IsResetOnCopy = true,
                    StringFormat = null,
                    CreationUserId = user.Id,
                    CreationDate = now,
                    LastUpdateUserId = user.Id,
                    LastUpdateDate = now,
                    EntityMetaField = new EntityMetaField
                    {
                        ValueTypeId = metaUser.Id,
                        DefaultValueId = null
                    }
                },
                new MetaField
                {
                    FieldName = "MinValue",
                    Label = "Valeur min.",
                    Description = "Valeur minimale de l'entier.",
                    IsRequired = false,
                    IsReadOnly = false,
                    IsVisible = true,
                    IsResetOnCopy = false,
                    StringFormat = null,
                    CreationUserId = user.Id,
                    CreationDate = now,
                    LastUpdateUserId = user.Id,
                    LastUpdateDate = now,
                    IntegerMetaField = new IntegerMetaField
                    {
                        MinValue = null,
                        MaxValue = null,
                        DefaultValue = null
                    }
                },
                new MetaField
                {
                    FieldName = "MaxValue",
                    Label = "Valeur max.",
                    Description = "Valeur maximale de l'entier.",
                    IsRequired = false,
                    IsReadOnly = false,
                    IsVisible = true,
                    IsResetOnCopy = false,
                    StringFormat = null,
                    CreationUserId = user.Id,
                    CreationDate = now,
                    LastUpdateUserId = user.Id,
                    LastUpdateDate = now,
                    IntegerMetaField = new IntegerMetaField
                    {
                        MinValue = null,
                        MaxValue = null,
                        DefaultValue = null
                    }
                },
                new MetaField
                {
                    FieldName = "DefaultValue",
                    Label = "Valeur défaut",
                    Description = "Valeur par défaut du champ.",
                    IsRequired = false,
                    IsReadOnly = false,
                    IsVisible = true,
                    IsResetOnCopy = false,
                    StringFormat = null,
                    CreationUserId = user.Id,
                    CreationDate = now,
                    LastUpdateUserId = user.Id,
                    LastUpdateDate = now,
                    IntegerMetaField = new IntegerMetaField
                    {
                        MinValue = null,
                        MaxValue = null,
                        DefaultValue = null
                    }
                }
            }
            };

        private static MetaEntity BuildMetaMetaEntity(RegularExpression technicalNameRegularExpression,
            MetaEntity metaUser, MdUser user, DateTime now) => new MetaEntity
            {
                InterfaceName = "IMetaEntity",
                Label = "Méta-entité",
                PlurialLabel = "Méta-entités",
                IsMasculine = false,
                Description = null,
                CreationUserId = user.Id,
                CreationDate = now,
                LastUpdateUserId = user.Id,
                LastUpdateDate = now,
                MetaFields = new List<MetaField>
            {
                new MetaField
                {
                    FieldName = "Id",
                    Label = "Identifiant",
                    Description = "Identifiant de l'entité.",
                    IsRequired = true,
                    IsReadOnly = true,
                    IsVisible = false,
                    IsResetOnCopy = true,
                    StringFormat = null,
                    CreationUserId = user.Id,
                    CreationDate = now,
                    LastUpdateUserId = user.Id,
                    LastUpdateDate = now,
                    IntegerMetaField = new IntegerMetaField
                    {
                        MaxValue = null,
                        MinValue = 0,
                        DefaultValue = null
                    }
                },
                new MetaField
                {
                    FieldName = "InterfaceName",
                    Label = "Interface",
                    Description = "Nom de l'interface de l'entité.",
                    IsRequired = true,
                    IsReadOnly = false,
                    IsVisible = true,
                    IsResetOnCopy = true,
                    StringFormat = null,
                    CreationUserId = user.Id,
                    CreationDate = now,
                    LastUpdateUserId = user.Id,
                    LastUpdateDate = now,
                    StringMetaField = new StringMetaField
                    {
                        MinLength = null,
                        MaxLength = 128,
                        DisplayedLinesCount = 1,
                        DefaultValue = null,
                        RegularExpressionId = technicalNameRegularExpression.Id
                    }
                },
                new MetaField
                {
                    FieldName = "Label",
                    Label = "Libellé",
                    Description = "Libellé de l'entité.",
                    IsRequired = true,
                    IsReadOnly = false,
                    IsVisible = true,
                    IsResetOnCopy = false,
                    StringFormat = null,
                    CreationUserId = user.Id,
                    CreationDate = now,
                    LastUpdateUserId = user.Id,
                    LastUpdateDate = now,
                    StringMetaField = new StringMetaField
                    {
                        MinLength = null,
                        MaxLength = 128,
                        DisplayedLinesCount = 1,
                        DefaultValue = null,
                        RegularExpressionId = null
                    }
                },
                new MetaField
                {
                    FieldName = "PlurialLabel",
                    Label = "Libellé pluriel",
                    Description = "Libellé de l'entité au pluriel.",
                    IsRequired = true,
                    IsReadOnly = false,
                    IsVisible = true,
                    IsResetOnCopy = false,
                    StringFormat = null,
                    CreationUserId = user.Id,
                    CreationDate = now,
                    LastUpdateUserId = user.Id,
                    LastUpdateDate = now,
                    StringMetaField = new StringMetaField
                    {
                        MinLength = null,
                        MaxLength = 128,
                        DisplayedLinesCount = 1,
                        DefaultValue = null,
                        RegularExpressionId = null
                    }
                },
                new MetaField
                {
                    FieldName = "IsMasculine",
                    Label = "Est masculin",
                    Description = "L'entité est-elle masculine?",
                    IsRequired = true,
                    IsReadOnly = false,
                    IsVisible = true,
                    IsResetOnCopy = false,
                    StringFormat = null,
                    CreationUserId = user.Id,
                    CreationDate = now,
                    LastUpdateUserId = user.Id,
                    LastUpdateDate = now,
                    BooleanMetaField = new BooleanMetaField
                    {
                        DefaultValue = null
                    }
                },
                new MetaField
                {
                    FieldName = "Description",
                    Label = "Description",
                    Description = "Description de l'entité.",
                    IsRequired = false,
                    IsReadOnly = false,
                    IsVisible = true,
                    IsResetOnCopy = false,
                    StringFormat = null,
                    CreationUserId = user.Id,
                    CreationDate = now,
                    LastUpdateUserId = user.Id,
                    LastUpdateDate = now,
                    StringMetaField = new StringMetaField
                    {
                        MinLength = null,
                        MaxLength = 1024,
                        DisplayedLinesCount = 3,
                        DefaultValue = null,
                        RegularExpressionId = null
                    }
                },
                new MetaField
                {
                    FieldName = "CreationDate",
                    Label = "Date création",
                    Description = "Date de création de l'entité.",
                    IsRequired = true,
                    IsReadOnly = true,
                    IsVisible = false,
                    IsResetOnCopy = true,
                    StringFormat = "d",
                    CreationUserId = user.Id,
                    CreationDate = now,
                    LastUpdateUserId = user.Id,
                    LastUpdateDate = now,
                    DateTimeMetaField = new DateTimeMetaField
                    {
                        MinValue = now.Date,
                        MaxValue = null,
                        IsDefaultValueNow = true,
                        DefaultValue = null
                    }
                },
                new MetaField
                {
                    FieldName = "CreationUser",
                    Label = "Utilisateur création",
                    Description = "Utilisateur ayant créé l'entité.",
                    IsRequired = true,
                    IsReadOnly = true,
                    IsVisible = false,
                    IsResetOnCopy = true,
                    StringFormat = null,
                    CreationUserId = user.Id,
                    CreationDate = now,
                    LastUpdateUserId = user.Id,
                    LastUpdateDate = now,
                    EntityMetaField = new EntityMetaField
                    {
                        ValueTypeId = metaUser.Id,
                        DefaultValueId = null
                    }
                },
                new MetaField
                {
                    FieldName = "LastUpdateDate",
                    Label = "Date mise à jour",
                    Description = "Date de dernière mise à jour de l'entité.",
                    IsRequired = true,
                    IsReadOnly = true,
                    IsVisible = false,
                    IsResetOnCopy = true,
                    StringFormat = "d",
                    CreationUserId = user.Id,
                    CreationDate = now,
                    LastUpdateUserId = user.Id,
                    LastUpdateDate = now,
                    DateTimeMetaField = new DateTimeMetaField
                    {
                        MinValue = now.Date,
                        MaxValue = null,
                        IsDefaultValueNow = true,
                        DefaultValue = null
                    }
                },
                new MetaField
                {
                    FieldName = "LastUpdateUser",
                    Label = "Utilisateur mise à jour",
                    Description = "Utilisateur ayant réalisé la dernière mise à jour de l'entité.",
                    IsRequired = true,
                    IsReadOnly = true,
                    IsVisible = false,
                    IsResetOnCopy = true,
                    StringFormat = null,
                    CreationUserId = user.Id,
                    CreationDate = now,
                    LastUpdateUserId = user.Id,
                    LastUpdateDate = now,
                    EntityMetaField = new EntityMetaField
                    {
                        ValueTypeId = metaUser.Id,
                        DefaultValueId = null
                    }
                }
            }
            };

        private static MetaEntity BuildMetaMetaField(RegularExpression technicalNameRegularExpression,
            MetaEntity metaMetaEntity, MetaEntity metaUser,
            MdUser user, DateTime now) => new MetaEntity
            {
                InterfaceName = "IMetaField",
                Label = "Méta-champ",
                PlurialLabel = "Méta-champs",
                IsMasculine = true,
                Description = null,
                CreationUserId = user.Id,
                CreationDate = now,
                LastUpdateUserId = user.Id,
                LastUpdateDate = now,
                MetaFields = new List<MetaField>
            {
                new MetaField
                {
                    FieldName = "Id",
                    Label = "Identifiant",
                    Description = "Identifiant du champ.",
                    IsRequired = true,
                    IsReadOnly = true,
                    IsVisible = false,
                    IsResetOnCopy = true,
                    StringFormat = null,
                    CreationUserId = user.Id,
                    CreationDate = now,
                    LastUpdateUserId = user.Id,
                    LastUpdateDate = now,
                    IntegerMetaField = new IntegerMetaField
                    {
                        MaxValue = null,
                        MinValue = 0,
                        DefaultValue = null
                    }
                },
                new MetaField
                {
                    FieldName = "MetaEntity",
                    Label = "Méta-entité",
                    Description = "Méta-entité du champ.",
                    IsRequired = true,
                    IsReadOnly = true,
                    IsVisible = true,
                    IsResetOnCopy = false,
                    StringFormat = null,
                    CreationUserId = user.Id,
                    CreationDate = now,
                    LastUpdateUserId = user.Id,
                    LastUpdateDate = now,
                    EntityMetaField = new EntityMetaField
                    {
                        ValueTypeId = metaMetaEntity.Id
                    }
                },
                new MetaField
                {
                    FieldName = "FieldName",
                    Label = "Nom",
                    Description = "Nom technique du champ.",
                    IsRequired = true,
                    IsReadOnly = false,
                    IsVisible = true,
                    IsResetOnCopy = true,
                    StringFormat = null,
                    CreationUserId = user.Id,
                    CreationDate = now,
                    LastUpdateUserId = user.Id,
                    LastUpdateDate = now,
                    StringMetaField = new StringMetaField
                    {
                        MinLength = null,
                        MaxLength = 128,
                        DisplayedLinesCount = 1,
                        DefaultValue = null,
                        RegularExpressionId = technicalNameRegularExpression.Id
                    }
                },
                new MetaField
                {
                    FieldName = "Label",
                    Label = "Libellé",
                    Description = "Libellé du champ.",
                    IsRequired = true,
                    IsReadOnly = false,
                    IsVisible = true,
                    IsResetOnCopy = false,
                    StringFormat = null,
                    CreationUserId = user.Id,
                    CreationDate = now,
                    LastUpdateUserId = user.Id,
                    LastUpdateDate = now,
                    StringMetaField = new StringMetaField
                    {
                        MinLength = null,
                        MaxLength = 128,
                        DisplayedLinesCount = 1,
                        DefaultValue = null,
                        RegularExpressionId = null
                    }
                },
                new MetaField
                {
                    FieldName = "Description",
                    Label = "Description",
                    Description = "Description du champ.",
                    IsRequired = false,
                    IsReadOnly = false,
                    IsVisible = true,
                    IsResetOnCopy = false,
                    StringFormat = null,
                    CreationUserId = user.Id,
                    CreationDate = now,
                    LastUpdateUserId = user.Id,
                    LastUpdateDate = now,
                    StringMetaField = new StringMetaField
                    {
                        MinLength = null,
                        MaxLength = 1024,
                        DisplayedLinesCount = 3,
                        DefaultValue = null,
                        RegularExpressionId = null
                    }
                },
                new MetaField
                {
                    FieldName = "IsRequired",
                    Label = "Requis",
                    Description = "Le champ est requis.",
                    IsRequired = true,
                    IsReadOnly = false,
                    IsVisible = true,
                    IsResetOnCopy = false,
                    StringFormat = null,
                    CreationUserId = user.Id,
                    CreationDate = now,
                    LastUpdateUserId = user.Id,
                    LastUpdateDate = now,
                    BooleanMetaField = new BooleanMetaField
                    {
                        DefaultValue = null
                    }
                },
                new MetaField
                {
                    FieldName = "IsReadOnly",
                    Label = "Lecture seule",
                    Description = "Le champ est en lecture seule.",
                    IsRequired = true,
                    IsReadOnly = false,
                    IsVisible = true,
                    IsResetOnCopy = false,
                    StringFormat = null,
                    CreationUserId = user.Id,
                    CreationDate = now,
                    LastUpdateUserId = user.Id,
                    LastUpdateDate = now,
                    BooleanMetaField = new BooleanMetaField
                    {
                        DefaultValue = null
                    }
                },
                new MetaField
                {
                    FieldName = "IsVisible",
                    Label = "Visible",
                    Description = "Le champ est visible dans les formulaires.",
                    IsRequired = true,
                    IsReadOnly = false,
                    IsVisible = true,
                    IsResetOnCopy = false,
                    CreationUserId = user.Id,
                    LastUpdateUserId = user.Id,
                    CreationDate = now,
                    LastUpdateDate = now,
                    StringFormat = null,
                    BooleanMetaField = new BooleanMetaField
                    {
                        DefaultValue = true
                    }
                },
                new MetaField
                {
                    FieldName = "IsResetOnCopy",
                    Label = "RaZ sur copie",
                    Description = "Le champ est remis à zéro lorsqu'il est copié.",
                    IsRequired = true,
                    IsReadOnly = false,
                    IsVisible = true,
                    IsResetOnCopy = false,
                    StringFormat = null,
                    CreationUserId = user.Id,
                    CreationDate = now,
                    LastUpdateUserId = user.Id,
                    LastUpdateDate = now,
                    BooleanMetaField = new BooleanMetaField
                    {
                        DefaultValue = null
                    }
                },
                new MetaField
                {
                    FieldName = "StringFormat",
                    Label = "Format de chaîne",
                    Description = "Format de la chaîne de caractère désignant la valeur du champ.",
                    IsRequired = false,
                    IsReadOnly = false,
                    IsVisible = true,
                    IsResetOnCopy = false,
                    StringFormat = null,
                    CreationUserId = user.Id,
                    CreationDate = now,
                    LastUpdateUserId = user.Id,
                    LastUpdateDate = now,
                    StringMetaField = new StringMetaField
                    {
                        MinLength = null,
                        MaxLength = 128,
                        DisplayedLinesCount = 1,
                        DefaultValue = null,
                        RegularExpressionId = null
                    }
                },
                new MetaField
                {
                    FieldName = "CreationDate",
                    Label = "Date création",
                    Description = "Date de création du méta-champ.",
                    IsRequired = true,
                    IsReadOnly = true,
                    IsVisible = false,
                    IsResetOnCopy = true,
                    StringFormat = "d",
                    CreationUserId = user.Id,
                    CreationDate = now,
                    LastUpdateUserId = user.Id,
                    LastUpdateDate = now,
                    DateTimeMetaField = new DateTimeMetaField
                    {
                        MinValue = now.Date,
                        MaxValue = null,
                        IsDefaultValueNow = true,
                        DefaultValue = null
                    }
                },
                new MetaField
                {
                    FieldName = "CreationUser",
                    Label = "Utilisateur création",
                    Description = "Utilisateur ayant créé l'entité.",
                    IsRequired = true,
                    IsReadOnly = true,
                    IsVisible = false,
                    IsResetOnCopy = true,
                    StringFormat = null,
                    CreationUserId = user.Id,
                    CreationDate = now,
                    LastUpdateUserId = user.Id,
                    LastUpdateDate = now,
                    EntityMetaField = new EntityMetaField
                    {
                        ValueTypeId = metaUser.Id,
                        DefaultValueId = null
                    }
                },
                new MetaField
                {
                    FieldName = "LastUpdateDate",
                    Label = "Date mise à jour",
                    Description = "Date de dernière mise à jour de l'entité.",
                    IsRequired = true,
                    IsReadOnly = true,
                    IsVisible = false,
                    IsResetOnCopy = true,
                    StringFormat = "d",
                    CreationUserId = user.Id,
                    CreationDate = now,
                    LastUpdateUserId = user.Id,
                    LastUpdateDate = now,
                    DateTimeMetaField = new DateTimeMetaField
                    {
                        MinValue = now.Date,
                        MaxValue = null,
                        IsDefaultValueNow = true,
                        DefaultValue = null
                    }
                },
                new MetaField
                {
                    FieldName = "LastUpdateUser",
                    Label = "Utilisateur mise à jour",
                    Description = "Utilisateur ayant réalisé la dernière mise à jour de l'entité.",
                    IsRequired = true,
                    IsReadOnly = true,
                    IsVisible = false,
                    IsResetOnCopy = true,
                    StringFormat = null,
                    CreationUserId = user.Id,
                    CreationDate = now,
                    LastUpdateUserId = user.Id,
                    LastUpdateDate = now,
                    EntityMetaField = new EntityMetaField
                    {
                        ValueTypeId = metaUser.Id,
                        DefaultValueId = null
                    }
                }
            }
            };

        private static MetaEntity BuildMetaRegularExpression(MetaEntity metaUser, MdUser user, DateTime now) =>
            new MetaEntity
            {
                InterfaceName = "IRegularExpression",
                Label = "Expression régulière",
                PlurialLabel = "Expressions régulières",
                IsMasculine = false,
                Description = null,
                CreationUserId = user.Id,
                CreationDate = now,
                LastUpdateUserId = user.Id,
                LastUpdateDate = now,
                MetaFields = new List<MetaField>
                {
                    new MetaField
                    {
                        FieldName = "Id",
                        Label = "Identifiant",
                        Description = "Identifiant de l'expression régulière.",
                        IsRequired = true,
                        IsReadOnly = true,
                        IsVisible = false,
                        IsResetOnCopy = true,
                        StringFormat = null,
                        CreationUserId = user.Id,
                        CreationDate = now,
                        LastUpdateUserId = user.Id,
                        LastUpdateDate = now,
                        IntegerMetaField = new IntegerMetaField
                        {
                            MaxValue = null,
                            MinValue = 0,
                            DefaultValue = null
                        }
                    },
                    new MetaField
                    {
                        FieldName = "Label",
                        Label = "Libellé",
                        Description = "Libellé de l'expression régulière.",
                        IsRequired = true,
                        IsReadOnly = false,
                        IsVisible = true,
                        IsResetOnCopy = false,
                        CreationUserId = user.Id,
                        LastUpdateUserId = user.Id,
                        CreationDate = now,
                        LastUpdateDate = now,
                        StringFormat = null,
                        StringMetaField = new StringMetaField
                        {
                            MinLength = null,
                            MaxLength = 128,
                            DisplayedLinesCount = 1,
                            DefaultValue = null,
                            RegularExpressionId = null
                        }
                    },
                    new MetaField
                    {
                        FieldName = "Pattern",
                        Label = "Modèle",
                        Description = "Modèle de l'expression régulière.",
                        IsRequired = true,
                        IsReadOnly = false,
                        IsVisible = true,
                        IsResetOnCopy = false,
                        CreationUserId = user.Id,
                        LastUpdateUserId = user.Id,
                        CreationDate = now,
                        LastUpdateDate = now,
                        StringFormat = null,
                        StringMetaField = new StringMetaField
                        {
                            MinLength = null,
                            MaxLength = 254,
                            DisplayedLinesCount = 1,
                            DefaultValue = null,
                            RegularExpressionId = null
                        }
                    },
                    new MetaField
                    {
                        FieldName = "InvalidMessage",
                        Label = "Message d'erreur",
                        Description =
                            "Message d'erreur affiché si la valeur ne correspond pas à l'expression régulière.",
                        IsRequired = true,
                        IsReadOnly = false,
                        IsVisible = true,
                        IsResetOnCopy = false,
                        CreationUserId = user.Id,
                        LastUpdateUserId = user.Id,
                        CreationDate = now,
                        LastUpdateDate = now,
                        StringFormat = null,
                        StringMetaField = new StringMetaField
                        {
                            MinLength = null,
                            MaxLength = 128,
                            DisplayedLinesCount = 1,
                            DefaultValue = null,
                            RegularExpressionId = null
                        }
                    },
                    new MetaField
                    {
                        FieldName = "Description",
                        Label = "Description",
                        Description = "Description de l'expression régulière.",
                        IsRequired = false,
                        IsReadOnly = false,
                        IsVisible = true,
                        IsResetOnCopy = false,
                        CreationUserId = user.Id,
                        LastUpdateUserId = user.Id,
                        CreationDate = now,
                        LastUpdateDate = now,
                        StringFormat = null,
                        StringMetaField = new StringMetaField
                        {
                            MinLength = null,
                            MaxLength = 1024,
                            DisplayedLinesCount = 3,
                            DefaultValue = null,
                            RegularExpressionId = null
                        }
                    },
                    new MetaField
                    {
                        FieldName = "CreationDate",
                        Label = "Date création",
                        Description = "Date de création de l'expression régulière.",
                        IsRequired = true,
                        IsReadOnly = true,
                        IsVisible = false,
                        IsResetOnCopy = true,
                        CreationUserId = user.Id,
                        LastUpdateUserId = user.Id,
                        CreationDate = now,
                        LastUpdateDate = now,
                        StringFormat = "d",
                        DateTimeMetaField = new DateTimeMetaField
                        {
                            MinValue = now.Date,
                            MaxValue = null,
                            IsDefaultValueNow = true,
                            DefaultValue = null
                        }
                    },
                    new MetaField
                    {
                        FieldName = "CreationUser",
                        Label = "Utilisateur création",
                        Description = "Utilisateur ayant créé l'expression régulière.",
                        IsRequired = true,
                        IsReadOnly = true,
                        IsVisible = false,
                        IsResetOnCopy = true,
                        CreationUserId = user.Id,
                        LastUpdateUserId = user.Id,
                        CreationDate = now,
                        LastUpdateDate = now,
                        StringFormat = null,
                        EntityMetaField = new EntityMetaField
                        {
                            ValueTypeId = metaUser.Id,
                            DefaultValueId = null
                        }
                    },
                    new MetaField
                    {
                        FieldName = "LastUpdateDate",
                        Label = "Date mise à jour",
                        Description = "Date de dernière mise à jour de l'expression régulière.",
                        IsRequired = true,
                        IsReadOnly = true,
                        IsVisible = false,
                        IsResetOnCopy = true,
                        CreationUserId = user.Id,
                        LastUpdateUserId = user.Id,
                        CreationDate = now,
                        LastUpdateDate = now,
                        StringFormat = "d",
                        DateTimeMetaField = new DateTimeMetaField
                        {
                            MinValue = now.Date,
                            MaxValue = null,
                            IsDefaultValueNow = true,
                            DefaultValue = null
                        }
                    },
                    new MetaField
                    {
                        FieldName = "LastUpdateUser",
                        Label = "Utilisateur mise à jour",
                        Description = "Utilisateur ayant réalisé la dernière mise à jour de l'expression régulière.",
                        IsRequired = true,
                        IsReadOnly = true,
                        IsVisible = false,
                        IsResetOnCopy = true,
                        CreationUserId = user.Id,
                        LastUpdateUserId = user.Id,
                        CreationDate = now,
                        LastUpdateDate = now,
                        StringFormat = null,
                        EntityMetaField = new EntityMetaField
                        {
                            ValueTypeId = metaUser.Id,
                            DefaultValueId = null
                        }
                    }
                }
            };

        private static MetaEntity BuildMetaStringMetaField(RegularExpression technicalNameRegularExpression,
            MetaEntity metaTechnicalNameRegularExpression,
            MetaEntity metaMetaEntity, MetaEntity metaUser, MdUser user, DateTime now) => new MetaEntity
            {
                InterfaceName = "IStringMetaField",
                Label = "Méta-champ chaîne de caractères",
                PlurialLabel = "Méta-champs chaîne de caractères",
                IsMasculine = true,
                Description = null,
                CreationUserId = user.Id,
                CreationDate = now,
                LastUpdateUserId = user.Id,
                LastUpdateDate = now,
                MetaFields = new List<MetaField>
            {
                new MetaField
                {
                    FieldName = "Id",
                    Label = "Identifiant",
                    Description = "Identifiant du champ.",
                    IsRequired = true,
                    IsReadOnly = true,
                    IsVisible = false,
                    IsResetOnCopy = true,
                    StringFormat = null,
                    CreationUserId = user.Id,
                    CreationDate = now,
                    LastUpdateUserId = user.Id,
                    LastUpdateDate = now,
                    IntegerMetaField = new IntegerMetaField
                    {
                        MaxValue = null,
                        MinValue = 0,
                        DefaultValue = null
                    }
                },
                new MetaField
                {
                    FieldName = "MetaEntity",
                    Label = "Méta-entité",
                    Description = "Méta-entité du champ.",
                    IsRequired = true,
                    IsReadOnly = true,
                    IsVisible = true,
                    IsResetOnCopy = false,
                    StringFormat = null,
                    CreationUserId = user.Id,
                    CreationDate = now,
                    LastUpdateUserId = user.Id,
                    LastUpdateDate = now,
                    EntityMetaField = new EntityMetaField
                    {
                        ValueTypeId = metaMetaEntity.Id
                    }
                },
                new MetaField
                {
                    FieldName = "FieldName",
                    Label = "Nom",
                    Description = "Nom technique du champ.",
                    IsRequired = true,
                    IsReadOnly = false,
                    IsVisible = true,
                    IsResetOnCopy = true,
                    StringFormat = null,
                    CreationUserId = user.Id,
                    CreationDate = now,
                    LastUpdateUserId = user.Id,
                    LastUpdateDate = now,
                    StringMetaField = new StringMetaField
                    {
                        MinLength = null,
                        MaxLength = 128,
                        DisplayedLinesCount = 1,
                        DefaultValue = null,
                        RegularExpressionId = technicalNameRegularExpression.Id
                    }
                },
                new MetaField
                {
                    FieldName = "Label",
                    Label = "Libellé",
                    Description = "Libellé du champ.",
                    IsRequired = true,
                    IsReadOnly = false,
                    IsVisible = true,
                    IsResetOnCopy = false,
                    StringFormat = null,
                    CreationUserId = user.Id,
                    CreationDate = now,
                    LastUpdateUserId = user.Id,
                    LastUpdateDate = now,
                    StringMetaField = new StringMetaField
                    {
                        MinLength = null,
                        MaxLength = 128,
                        DisplayedLinesCount = 1,
                        DefaultValue = null,
                        RegularExpressionId = null
                    }
                },
                new MetaField
                {
                    FieldName = "Description",
                    Label = "Description",
                    Description = "Description du champ.",
                    IsRequired = false,
                    IsReadOnly = false,
                    IsVisible = true,
                    IsResetOnCopy = false,
                    StringFormat = null,
                    CreationUserId = user.Id,
                    CreationDate = now,
                    LastUpdateUserId = user.Id,
                    LastUpdateDate = now,
                    StringMetaField = new StringMetaField
                    {
                        MinLength = null,
                        MaxLength = 1024,
                        DisplayedLinesCount = 3,
                        DefaultValue = null,
                        RegularExpressionId = null
                    }
                },
                new MetaField
                {
                    FieldName = "IsRequired",
                    Label = "Requis",
                    Description = "Le champ est requis.",
                    IsRequired = true,
                    IsReadOnly = false,
                    IsVisible = true,
                    IsResetOnCopy = false,
                    StringFormat = null,
                    CreationUserId = user.Id,
                    CreationDate = now,
                    LastUpdateUserId = user.Id,
                    LastUpdateDate = now,
                    BooleanMetaField = new BooleanMetaField
                    {
                        DefaultValue = null
                    }
                },
                new MetaField
                {
                    FieldName = "IsReadOnly",
                    Label = "Lecture seule",
                    Description = "Le champ est en lecture seule.",
                    IsRequired = true,
                    IsReadOnly = false,
                    IsVisible = true,
                    IsResetOnCopy = false,
                    StringFormat = null,
                    CreationUserId = user.Id,
                    CreationDate = now,
                    LastUpdateUserId = user.Id,
                    LastUpdateDate = now,
                    BooleanMetaField = new BooleanMetaField
                    {
                        DefaultValue = null
                    }
                },
                new MetaField
                {
                    FieldName = "IsVisible",
                    Label = "Visible",
                    Description = "Le champ est visible dans les formulaires.",
                    IsRequired = true,
                    IsReadOnly = false,
                    IsVisible = true,
                    IsResetOnCopy = false,
                    CreationUserId = user.Id,
                    LastUpdateUserId = user.Id,
                    CreationDate = now,
                    LastUpdateDate = now,
                    StringFormat = null,
                    BooleanMetaField = new BooleanMetaField
                    {
                        DefaultValue = null
                    }
                },
                new MetaField
                {
                    FieldName = "IsResetOnCopy",
                    Label = "RaZ sur copie",
                    Description = "Le champ est remis à zéro lorsqu'il est copié.",
                    IsRequired = true,
                    IsReadOnly = false,
                    IsVisible = true,
                    IsResetOnCopy = false,
                    StringFormat = null,
                    CreationUserId = user.Id,
                    CreationDate = now,
                    LastUpdateUserId = user.Id,
                    LastUpdateDate = now,
                    BooleanMetaField = new BooleanMetaField
                    {
                        DefaultValue = null
                    }
                },
                new MetaField
                {
                    FieldName = "StringFormat",
                    Label = "Format de chaîne",
                    Description = "Format de la chaîne de caractère désignant la valeur du champ.",
                    IsRequired = false,
                    IsReadOnly = false,
                    IsVisible = true,
                    IsResetOnCopy = false,
                    StringFormat = null,
                    CreationUserId = user.Id,
                    CreationDate = now,
                    LastUpdateUserId = user.Id,
                    LastUpdateDate = now,
                    StringMetaField = new StringMetaField
                    {
                        MinLength = null,
                        MaxLength = 128,
                        DisplayedLinesCount = 1,
                        DefaultValue = null,
                        RegularExpressionId = null
                    }
                },
                new MetaField
                {
                    FieldName = "CreationDate",
                    Label = "Date création",
                    Description = "Date de création du méta-champ.",
                    IsRequired = true,
                    IsReadOnly = true,
                    IsVisible = false,
                    IsResetOnCopy = true,
                    StringFormat = "d",
                    CreationUserId = user.Id,
                    CreationDate = now,
                    LastUpdateUserId = user.Id,
                    LastUpdateDate = now,
                    DateTimeMetaField = new DateTimeMetaField
                    {
                        MinValue = now.Date,
                        MaxValue = null,
                        IsDefaultValueNow = true,
                        DefaultValue = null
                    }
                },
                new MetaField
                {
                    FieldName = "CreationUser",
                    Label = "Utilisateur création",
                    Description = "Utilisateur ayant créé le méta-champ.",
                    IsRequired = true,
                    IsReadOnly = true,
                    IsVisible = false,
                    IsResetOnCopy = true,
                    StringFormat = null,
                    CreationUserId = user.Id,
                    CreationDate = now,
                    LastUpdateUserId = user.Id,
                    LastUpdateDate = now,
                    EntityMetaField = new EntityMetaField
                    {
                        ValueTypeId = metaUser.Id,
                        DefaultValueId = null
                    }
                },
                new MetaField
                {
                    FieldName = "LastUpdateDate",
                    Label = "Date mise à jour",
                    Description = "Date de dernière mise à jour du méta-champ.",
                    IsRequired = true,
                    IsReadOnly = true,
                    IsVisible = false,
                    IsResetOnCopy = true,
                    StringFormat = "d",
                    CreationUserId = user.Id,
                    CreationDate = now,
                    LastUpdateUserId = user.Id,
                    LastUpdateDate = now,
                    DateTimeMetaField = new DateTimeMetaField
                    {
                        MinValue = now.Date,
                        MaxValue = null,
                        IsDefaultValueNow = true,
                        DefaultValue = null
                    }
                },
                new MetaField
                {
                    FieldName = "LastUpdateUser",
                    Label = "Utilisateur mise à jour",
                    Description = "Utilisateur ayant réalisé la dernière mise à jour du méta-champ.",
                    IsRequired = true,
                    IsReadOnly = true,
                    IsVisible = false,
                    IsResetOnCopy = true,
                    StringFormat = null,
                    CreationUserId = user.Id,
                    CreationDate = now,
                    LastUpdateUserId = user.Id,
                    LastUpdateDate = now,
                    EntityMetaField = new EntityMetaField
                    {
                        ValueTypeId = metaUser.Id,
                        DefaultValueId = null
                    }
                },
                new MetaField
                {
                    FieldName = "MinLength",
                    Label = "Taille min.",
                    Description = "Taille minimale de la chaîne de caractère.",
                    IsRequired = false,
                    IsReadOnly = false,
                    IsVisible = true,
                    IsResetOnCopy = false,
                    StringFormat = null,
                    CreationUserId = user.Id,
                    CreationDate = now,
                    LastUpdateUserId = user.Id,
                    LastUpdateDate = now,
                    IntegerMetaField = new IntegerMetaField
                    {
                        MinValue = 0,
                        MaxValue = 100000,
                        DefaultValue = 0
                    }
                },
                new MetaField
                {
                    FieldName = "MaxLength",
                    Label = "Taille max.",
                    Description = "Taille maximale de la chaîne de caractère (nulle si illimité).",
                    IsRequired = false,
                    IsReadOnly = false,
                    IsVisible = true,
                    IsResetOnCopy = false,
                    StringFormat = null,
                    CreationUserId = user.Id,
                    CreationDate = now,
                    LastUpdateUserId = user.Id,
                    LastUpdateDate = now,
                    IntegerMetaField = new IntegerMetaField
                    {
                        MinValue = 0,
                        MaxValue = 100000,
                        DefaultValue = null
                    }
                },
                new MetaField
                {
                    FieldName = "DisplayedLinesCount",
                    Label = "Lignes affichées",
                    Description = "Nombre de lignes affichées dans le formulaire.",
                    IsRequired = true,
                    IsReadOnly = false,
                    IsVisible = true,
                    IsResetOnCopy = false,
                    StringFormat = null,
                    CreationUserId = user.Id,
                    CreationDate = now,
                    LastUpdateUserId = user.Id,
                    LastUpdateDate = now,
                    IntegerMetaField = new IntegerMetaField
                    {
                        MinValue = 1,
                        MaxValue = 100,
                        DefaultValue = 1
                    }
                },
                new MetaField
                {
                    FieldName = "DefaultValue",
                    Label = "Valeur défaut",
                    Description = "Valeur par défaut du champ.",
                    IsRequired = false,
                    IsReadOnly = false,
                    IsVisible = true,
                    IsResetOnCopy = false,
                    StringFormat = null,
                    CreationUserId = user.Id,
                    CreationDate = now,
                    LastUpdateUserId = user.Id,
                    LastUpdateDate = now,
                    StringMetaField = new StringMetaField
                    {
                        MinLength = null,
                        MaxLength = 128,
                        DisplayedLinesCount = 1,
                        DefaultValue = null,
                        RegularExpressionId = null
                    }
                },
                new MetaField
                {
                    FieldName = "RegularExpression",
                    Label = "Expression régulière",
                    Description = "Expression régulière que la valeur doit respecter.",
                    IsRequired = false,
                    IsReadOnly = false,
                    IsVisible = true,
                    IsResetOnCopy = false,
                    StringFormat = null,
                    CreationUserId = user.Id,
                    CreationDate = now,
                    LastUpdateUserId = user.Id,
                    LastUpdateDate = now,
                    EntityMetaField = new EntityMetaField
                    {
                        ValueTypeId = metaTechnicalNameRegularExpression.Id,
                        DefaultValueId = null
                    }
                }
            }
            };

        private static MetaEntity BuildMetaUser(MdUser user, DateTime now) => new MetaEntity
        {
            InterfaceName = "IMdUser",
            Label = "Utilisateur MD",
            PlurialLabel = "Utilisateurs MD",
            IsMasculine = true,
            Description = "Utilisateur de l'application MD Manager.",
            CreationUserId = user.Id,
            CreationDate = now,
            LastUpdateUserId = user.Id,
            LastUpdateDate = now,
            MetaFields = new List<MetaField>
            {
                new MetaField
                {
                    FieldName = "Id",
                    Label = "Identifiant",
                    Description = "Identifiant de l'utilisateur MD.",
                    IsRequired = true,
                    IsReadOnly = true,
                    IsVisible = false,
                    IsResetOnCopy = true,
                    StringFormat = null,
                    CreationUserId = user.Id,
                    CreationDate = now,
                    LastUpdateUserId = user.Id,
                    LastUpdateDate = now,
                    IntegerMetaField = new IntegerMetaField
                    {
                        MaxValue = null,
                        MinValue = 0,
                        DefaultValue = null
                    }
                },
                new MetaField
                {
                    FieldName = "Login",
                    Label = "Login",
                    Description = "Identifiant de connexion de l'utilisateur MD.",
                    IsRequired = true,
                    IsReadOnly = false,
                    IsVisible = true,
                    IsResetOnCopy = false,
                    StringFormat = null,
                    CreationUserId = user.Id,
                    CreationDate = now,
                    LastUpdateUserId = user.Id,
                    LastUpdateDate = now,
                    StringMetaField = new StringMetaField
                    {
                        MinLength = null,
                        MaxLength = 128,
                        DisplayedLinesCount = 1,
                        DefaultValue = null,
                        RegularExpressionId = null
                    }
                },
                new MetaField
                {
                    FieldName = "Password",
                    Label = "Mot de passe",
                    Description = "Mot de passe de l'utilisateur MD.",
                    IsRequired = true,
                    IsReadOnly = false,
                    IsVisible = true,
                    IsResetOnCopy = true,
                    StringFormat = null,
                    CreationUserId = user.Id,
                    CreationDate = now,
                    LastUpdateUserId = user.Id,
                    LastUpdateDate = now,
                    StringMetaField = new StringMetaField
                    {
                        MinLength = null,
                        MaxLength = 128,
                        DisplayedLinesCount = 1,
                        DefaultValue = null,
                        RegularExpressionId = null
                    }
                }
            }
        };

        private static RegularExpression BuildTechnicalNameRegularExpression(MdUser user, DateTime date) =>
            new RegularExpression
            {
                Label = "Nom technique",
                Pattern = @"[A-Z]\w*\D\S",
                InvalidMessage = "La valeur contient des caractères non autorisés.",
                Description = "Nom utilisé dans le code source d'une application.",
                CreationDate = date,
                CreationUserId = user.Id,
                LastUpdateDate = date,
                LastUpdateUserId = user.Id
            };

        private static List<MetaField> BuildMetaFieldTemplates(RegularExpression technicalNameRegularExpression,
            MetaEntity metaUser, MdUser user, DateTime now, MetaEntity metaMetaEntity)
        {
            return new List<MetaField>
            {
                 new MetaField
                {
                    FieldName = "Id",
                    Label = "Identifiant",
                    Description = null,
                    IsRequired = true,
                    IsReadOnly = true,
                    IsVisible = false,
                    IsResetOnCopy = true,
                    StringFormat = null,
                    CreationUserId = user.Id,
                    CreationDate = now,
                    LastUpdateUserId = user.Id,
                    LastUpdateDate = now,
                    ParentMetaFieldId = null,
                    IntegerMetaField = new IntegerMetaField
                    {
                        MaxValue = null,
                        MinValue = 0,
                        DefaultValue = null
                    }
                },
                new MetaField
                {
                    FieldName = "TechnicalName",
                    Label = "Nom technique",
                    Description = null,
                    IsRequired = true,
                    IsReadOnly = false,
                    IsVisible = true,
                    IsResetOnCopy = true,
                    StringFormat = null,
                    CreationUserId = user.Id,
                    CreationDate = now,
                    LastUpdateUserId = user.Id,
                    LastUpdateDate = now,
                    ParentMetaFieldId = null,
                    StringMetaField = new StringMetaField
                    {
                        MinLength = null,
                        MaxLength = 128,
                        DisplayedLinesCount = 1,
                        DefaultValue = null,
                        RegularExpressionId = technicalNameRegularExpression.Id
                    }
                },
                new MetaField
                {
                    FieldName = "Label",
                    Label = "Libellé",
                    Description = null,
                    IsRequired = true,
                    IsReadOnly = false,
                    IsVisible = true,
                    IsResetOnCopy = false,
                    StringFormat = null,
                    CreationUserId = user.Id,
                    CreationDate = now,
                    LastUpdateUserId = user.Id,
                    LastUpdateDate = now,
                    ParentMetaFieldId = null,
                    StringMetaField = new StringMetaField
                    {
                        MinLength = null,
                        MaxLength = 128,
                        DisplayedLinesCount = 1,
                        DefaultValue = null,
                        RegularExpressionId = null
                    }
                },
              new MetaField
              {
                  FieldName = "Description",
                  Label = "Description",
                  Description = null,
                  IsRequired = false,
                  IsReadOnly = false,
                  IsVisible = true,
                  IsResetOnCopy = false,
                  StringFormat = null,
                  CreationUserId = user.Id,
                  CreationDate = now,
                  LastUpdateUserId = user.Id,
                  LastUpdateDate = now,
                  ParentMetaFieldId = null,
                  StringMetaField = new StringMetaField
                  {
                      MinLength = null,
                      MaxLength = 1024,
                      DisplayedLinesCount = 3,
                      DefaultValue = null,
                      RegularExpressionId = null
                  }
              },
              new MetaField
              {
                  FieldName = "Message",
                  Label = "Message",
                  Description = null,
                  IsRequired = true,
                  IsReadOnly = false,
                  IsVisible = true,
                  IsResetOnCopy = false,
                  StringFormat = null,
                  CreationUserId = user.Id,
                  CreationDate = now,
                  LastUpdateUserId = user.Id,
                  LastUpdateDate = now,
                  ParentMetaFieldId = null,
                  StringMetaField = new StringMetaField
                  {
                      MinLength = null,
                      MaxLength = 128,
                      DisplayedLinesCount = 1,
                      DefaultValue = null,
                      RegularExpressionId = null
                  }
              },
              new MetaField
              {
                  FieldName = "Length",
                  Label = "Nombre de caractère",
                  Description = null,
                  IsRequired = true,
                  IsReadOnly = true,
                  IsVisible = false,
                  IsResetOnCopy = true,
                  StringFormat = null,
                  CreationUserId = user.Id,
                  CreationDate = now,
                  LastUpdateUserId = user.Id,
                  LastUpdateDate = now,
                  ParentMetaFieldId = null,
                  IntegerMetaField = new IntegerMetaField
                  {
                      MaxValue = null,
                      MinValue = 0,
                      DefaultValue = null
                  }
              },
              new MetaField
              {
                  FieldName = "DisplayLineCount",
                  Label = "Nombre de ligne",
                  Description = null,
                  IsRequired = true,
                  IsReadOnly = true,
                  IsVisible = false,
                  IsResetOnCopy = true,
                  StringFormat = null,
                  CreationUserId = user.Id,
                  CreationDate = now,
                  LastUpdateUserId = user.Id,
                  LastUpdateDate = now,
                  ParentMetaFieldId = null,
                  IntegerMetaField = new IntegerMetaField
                  {
                      MaxValue = null,
                      MinValue = 0,
                      DefaultValue = null
                  }
              },
              new MetaField
              {
                  FieldName = "SystemDate",
                  Label = "Date système",
                  Description = null,
                  IsRequired = true,
                  IsReadOnly = true,
                  IsVisible = false,
                  IsResetOnCopy = true,
                  StringFormat = "d",
                  CreationUserId = user.Id,
                  CreationDate = now,
                  LastUpdateUserId = user.Id,
                  LastUpdateDate = now,
                  ParentMetaFieldId = null,
                  DateTimeMetaField = new DateTimeMetaField
                  {
                      MinValue = now.Date,
                      MaxValue = null,
                      IsDefaultValueNow = true,
                      DefaultValue = null
                  }
              },
              new MetaField
              {
                  FieldName = "StringFormat",
                  Label = "Format de chaine",
                  Description = null,
                  IsRequired = true,
                  IsReadOnly = false,
                  IsVisible = true,
                  IsResetOnCopy = false,
                  StringFormat = null,
                  CreationUserId = user.Id,
                  CreationDate = now,
                  LastUpdateUserId = user.Id,
                  LastUpdateDate = now,
                  ParentMetaFieldId = null,
                  StringMetaField = new StringMetaField
                  {
                      MinLength = null,
                      MaxLength = 128,
                      DisplayedLinesCount = 1,
                      DefaultValue = null,
                      RegularExpressionId = null
                  }
              },
              new MetaField
              {
                  FieldName = "RegularExpression",
                  Label = "Expression régulière",
                  Description = null,
                  IsRequired = true,
                  IsReadOnly = true,
                  IsVisible = false,
                  IsResetOnCopy = true,
                  StringFormat = null,
                  CreationUserId = user.Id,
                  CreationDate = now,
                  LastUpdateUserId = user.Id,
                  LastUpdateDate = now,
                  ParentMetaFieldId = null,
                  EntityMetaField = new EntityMetaField
                  {
                      ValueTypeId = metaUser.Id,
                      DefaultValueId = null
                  }
              },
              new MetaField
              {
                  FieldName = "RegularExpressionPattern",
                  Label = "Modèle",
                  Description = "Model de l'expression régulière",
                  IsRequired = false,
                  IsReadOnly = false,
                  IsVisible = true,
                  IsResetOnCopy = false,
                  StringFormat = null,
                  CreationUserId = user.Id,
                  CreationDate = now,
                  LastUpdateUserId = user.Id,
                  LastUpdateDate = now,
                  ParentMetaFieldId = null,
                  StringMetaField = new StringMetaField
                  {
                      MinLength = null,
                      MaxLength = 1024,
                      DisplayedLinesCount = 3,
                      DefaultValue = null,
                      RegularExpressionId = null
                  }
              },
                new MetaField
                {
                    FieldName = "Boolean",
                    Label = "Booléen",
                    Description = null,
                    IsRequired = true,
                    IsReadOnly = false,
                    IsVisible = true,
                    IsResetOnCopy = false,
                    StringFormat = null,
                    CreationUserId = user.Id,
                    CreationDate = now,
                    LastUpdateUserId = user.Id,
                    LastUpdateDate = now,
                    ParentMetaFieldId = null,
                    BooleanMetaField = new BooleanMetaField
                    {
                        DefaultValue = null
                    }
                },
                new MetaField
                {
                    FieldName = "SystemUser",
                    Label = "Utilisateur système",
                    Description = null,
                    IsRequired = true,
                    IsReadOnly = true,
                    IsVisible = false,
                    IsResetOnCopy = true,
                    StringFormat = null,
                    CreationUserId = user.Id,
                    CreationDate = now,
                    LastUpdateUserId = user.Id,
                    LastUpdateDate = now,
                    ParentMetaFieldId = null,
                    EntityMetaField = new EntityMetaField
                    {
                        ValueTypeId = metaUser.Id,
                        DefaultValueId = null
                    }
                },
                new MetaField
                {
                    FieldName = "DefaultValueInteger",
                    Label = "Valeur par défaut",
                    Description = "Valeur par défaut entier",
                    IsRequired = true,
                    IsReadOnly = true,
                    IsVisible = true,
                    IsResetOnCopy = false,
                    StringFormat = null,
                    CreationUserId = user.Id,
                    CreationDate = now,
                    LastUpdateUserId = user.Id,
                    LastUpdateDate = now,
                    ParentMetaFieldId = null,
                    IntegerMetaField = new IntegerMetaField
                    {
                        MaxValue = null,
                        MinValue = 0,
                        DefaultValue = null
                    }
                },
                new MetaField
                  {
                  FieldName = "DefaultValueString",
                  Label = "Texte par défaut",
                  Description = "Texte par défaut",
                  IsRequired = false,
                  IsReadOnly = false,
                  IsVisible = true,
                  IsResetOnCopy = false,
                  StringFormat = null,
                  CreationUserId = user.Id,
                  CreationDate = now,
                  LastUpdateUserId = user.Id,
                  LastUpdateDate = now,
                      ParentMetaFieldId = null,
                  StringMetaField = new StringMetaField
                  {
                      MinLength = null,
                      MaxLength = 1024,
                      DisplayedLinesCount = 3,
                      DefaultValue = null,
                      RegularExpressionId = null
                  }
              },
              new MetaField
              {
                  FieldName = "DefaultValueDecimal",
                  Label = "Valeur par défaut",
                  Description = "Valeur décimale par défaut",
                  IsRequired = false,
                  IsReadOnly = false,
                  IsVisible = true,
                  IsResetOnCopy = false,
                  StringFormat = null,
                  CreationUserId = user.Id,
                  CreationDate = now,
                  LastUpdateUserId = user.Id,
                  LastUpdateDate = now,
                  ParentMetaFieldId = null,
                  DecimalMetaField = new DecimalMetaField
                  {
                      MinValue = null,
                      MaxValue = null,
                      Scale = 9,
                      DefaultValue = null
                  }
              },
              new MetaField
              {
                  FieldName = "DefaultValueDate",
                  Label = "Date par défaut",
                  Description = null,
                  IsRequired = true,
                  IsReadOnly = true,
                  IsVisible = false,
                  IsResetOnCopy = true,
                  StringFormat = "d",
                  CreationUserId = user.Id,
                  CreationDate = now,
                  LastUpdateUserId = user.Id,
                  LastUpdateDate = now,
                  ParentMetaFieldId = null,
                  DateTimeMetaField = new DateTimeMetaField
                  {
                      MinValue = now.Date,
                      MaxValue = null,
                      IsDefaultValueNow = true,
                      DefaultValue = null
                  }
              },
              new MetaField
              {
                  FieldName = "DefaultValueBoolean",
                  Label = "Booléen par défaut",
                  Description = "Valeur booléenne par défaut",
                  IsRequired = true,
                  IsReadOnly = false,
                  IsVisible = true,
                  IsResetOnCopy = false,
                  StringFormat = null,
                  CreationUserId = user.Id,
                  CreationDate = now,
                  LastUpdateUserId = user.Id,
                  LastUpdateDate = now,
                  ParentMetaFieldId = null,
                  BooleanMetaField = new BooleanMetaField
                  {
                      DefaultValue = null
                  }
              },
               new MetaField
                {
                    FieldName = "IntLimit",
                    Label = "Borne pour entier",
                    Description = "Borne pour les entiers",
                    IsRequired = true,
                    IsReadOnly = true,
                    IsVisible = true,
                    IsResetOnCopy = false,
                    StringFormat = null,
                    CreationUserId = user.Id,
                    CreationDate = now,
                    LastUpdateUserId = user.Id,
                    LastUpdateDate = now,
                    ParentMetaFieldId = null,
                    IntegerMetaField = new IntegerMetaField
                    {
                        MaxValue = null,
                        MinValue = 0,
                        DefaultValue = null
                    }
                },
              new MetaField
              {
                  FieldName = "DecimalLimit",
                  Label = "Borne pour décimale",
                  Description = "Borne pour les valeures décimales",
                  IsRequired = false,
                  IsReadOnly = false,
                  IsVisible = true,
                  IsResetOnCopy = false,
                  StringFormat = null,
                  CreationUserId = user.Id,
                  CreationDate = now,
                  LastUpdateUserId = user.Id,
                  LastUpdateDate = now,
                  ParentMetaFieldId = null,
                  DecimalMetaField = new DecimalMetaField
                  {
                      MinValue = null,
                      MaxValue = null,
                      Scale = 9,
                      DefaultValue = null
                  }
              },
              new MetaField
              {
                  FieldName = "DateLimit",
                  Label = "Borne pour date",
                  Description = "Bornes pour les dates",
                  IsRequired = true,
                  IsReadOnly = true,
                  IsVisible = false,
                  IsResetOnCopy = true,
                  StringFormat = "d",
                  CreationUserId = user.Id,
                  CreationDate = now,
                  LastUpdateUserId = user.Id,
                  LastUpdateDate = now,
                  ParentMetaFieldId = null,
                  DateTimeMetaField = new DateTimeMetaField
                  {
                      MinValue = now.Date,
                      MaxValue = null,
                      IsDefaultValueNow = true,
                      DefaultValue = null
                  }
              },
                new MetaField
                {
                    FieldName = "ParameterKey",
                    Label = "Parèmetre",
                    Description = "Paramètre système",
                    IsRequired = false,
                    IsReadOnly = false,
                    IsVisible = true,
                    IsResetOnCopy = false,
                    StringFormat = null,
                    CreationUserId = user.Id,
                    CreationDate = now,
                    LastUpdateUserId = user.Id,
                    LastUpdateDate = now,
                    ParentMetaFieldId = null,
                    StringMetaField = new StringMetaField
                    {
                        MinLength = null,
                        MaxLength = 1024,
                        DisplayedLinesCount = 3,
                        DefaultValue = null,
                        RegularExpressionId = null
                    }
                },
                new MetaField
                {
                    FieldName = "Scale",
                    Label = "Échelle",
                    Description = null,
                    IsRequired = true,
                    IsReadOnly = true,
                    IsVisible = true,
                    IsResetOnCopy = false,
                    StringFormat = null,
                    CreationUserId = user.Id,
                    CreationDate = now,
                    LastUpdateUserId = user.Id,
                    LastUpdateDate = now,
                    ParentMetaFieldId = null,
                    IntegerMetaField = new IntegerMetaField
                    {
                        MaxValue = null,
                        MinValue = 0,
                        DefaultValue = null
                    }
                },
                new MetaField
                {
                    FieldName = "MetaEntity",
                    Label = "Méta-entité",
                    Description = "Méta-entité du champ",
                    IsRequired = true,
                    IsReadOnly = true,
                    IsVisible = true,
                    IsResetOnCopy = false,
                    StringFormat = null,
                    CreationUserId = user.Id,
                    CreationDate = now,
                    LastUpdateUserId = user.Id,
                    LastUpdateDate = now,
                    ParentMetaFieldId = null,
                    EntityMetaField = new EntityMetaField
                    {
                        ValueTypeId = metaMetaEntity.Id,
                        ValueType =  null
                    }
                },
                new MetaField
                {
                    FieldName = "MetaField",
                    Label = "MetaField",
                    Description = null,
                    IsRequired = true,
                    IsReadOnly = true,
                    IsVisible = true,
                    IsResetOnCopy = false,
                    StringFormat = null,
                    CreationUserId = user.Id,
                    CreationDate = now,
                    LastUpdateUserId = user.Id,
                    LastUpdateDate = now,
                    ParentMetaFieldId = null,
                    EntityMetaField = new EntityMetaField
                    {
                        ValueTypeId = metaMetaEntity.Id
                    }
                },
            };
        }

        private static MdUser BuildUser() => new MdUser
        {
            Login = "admin",
            Password = "admin"
        };

        private static void CreateData()
        {
            Console.Write("Création des données : ");

            var now = DateTime.Now;
            using (var context = new FrameworkModelContext())
            {
                try
                {
                    var user = BuildUser();
                    context.MdUsers.Add(user);
                    context.SaveChanges();

                    var metaUser = BuildMetaUser(user, now);
                    context.MetaEntities.Add(metaUser);
                    var technicalNameRegularExpression = BuildTechnicalNameRegularExpression(user, now);
                    context.RegularExpressions.Add(technicalNameRegularExpression);
                    context.SaveChanges();

                    var metaMetaEntity = BuildMetaMetaEntity(technicalNameRegularExpression, metaUser, user, now);
                    context.MetaEntities.Add(metaMetaEntity);
                    var metaTechnicalNameRegularExpression = BuildMetaRegularExpression(metaUser, user, now);
                    context.MetaEntities.Add(metaTechnicalNameRegularExpression);
                    context.SaveChanges();

                    var id = 1;
                    var metaFieldTemplates = BuildMetaFieldTemplates(technicalNameRegularExpression, metaUser, user, now, metaMetaEntity);
                    foreach (var metaFieldTemplate in metaFieldTemplates)
                    {
                        metaFieldTemplate.Id = id;
                        context.MetaFields.Add(metaFieldTemplate);
                        Templatedictionary.Add(id, metaFieldTemplate);
                        id++;
                    }
                    context.SaveChanges();

                    var metaMetaField = BuildMetaMetaField(technicalNameRegularExpression, metaMetaEntity, metaUser,
                         user, now);
                    context.MetaEntities.Add(metaMetaField);

                    metaMetaField = BuildMetaStringMetaField(technicalNameRegularExpression,
                        metaTechnicalNameRegularExpression, metaMetaEntity, metaUser, user, now);
                    context.MetaEntities.Add(metaMetaField);

                    context.MetaEntities.Add(metaMetaField);
                    metaMetaField = BuildMetaBooleanMetaField(technicalNameRegularExpression, metaMetaEntity, metaUser,
                        user, now);
                    context.MetaEntities.Add(metaMetaField);
                    metaMetaField = BuildMetaIntegerMetaField(technicalNameRegularExpression, metaMetaEntity, metaUser,
                        user, now);
                    context.MetaEntities.Add(metaMetaField);
                    metaMetaField = BuildMetaDecimalMetaField(technicalNameRegularExpression, metaMetaEntity, metaUser,
                        user, now);
                    context.MetaEntities.Add(metaMetaField);
                    metaMetaField = BuildMetaDateTimeMetaField(technicalNameRegularExpression, metaMetaEntity, metaUser,
                        user, now);
                    context.MetaEntities.Add(metaMetaField);
                    metaMetaField = BuildMetaEntityMetaField(technicalNameRegularExpression, metaMetaEntity, metaUser,
                        user, now);
                    context.MetaEntities.Add(metaMetaField);

                    context.SaveChanges();

                    ManageFieldRelation(Templatedictionary, context);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
            Console.Write("OK");
            Console.WriteLine();
        }



        private static void ManageFieldRelation(Dictionary<int, MetaField> templaDictionary, FrameworkModelContext context)
        {

            var metaFields = context.MetaFields.ToList();

            foreach (var metaField in metaFields)
            {
                if (metaField.FieldName.Contains("Id") && metaField.MetaEntityId != null)
                {
                    metaField.ParentMetaFieldId = Templatedictionary[1].Id;
                }
                if ((metaField.FieldName.Contains("PlurialLabel") || metaField.FieldName.Contains("Pattern") ||
                    metaField.FieldName.Contains("InterfaceName") || metaField.FieldName.Contains("Login") ||
                    metaField.FieldName.Contains("Password")) && metaField.MetaEntityId != null)
                {
                    metaField.ParentMetaFieldId = Templatedictionary[2].Id;
                }
                if ((metaField.FieldName.Contains("TechnicalName") || metaField.FieldName.Contains("Password") ||
                    metaField.FieldName.Contains("FieldName") || metaField.FieldName.Contains("Label"))
                    && metaField.MetaEntityId != null)
                {
                    metaField.ParentMetaFieldId = Templatedictionary[3].Id;
                }
                if (metaField.FieldName == "Description" && (metaField.MetaEntityId != null))
                {
                    metaField.ParentMetaFieldId = Templatedictionary[4].Id;
                }
                if (metaField.FieldName.Contains("Message") && metaField.MetaEntityId != null)
                {
                    metaField.ParentMetaFieldId = Templatedictionary[5].Id;
                }
                if (metaField.FieldName.Contains("DisplayedLinesCount") && metaField.MetaEntityId != null)
                {
                    metaField.ParentMetaFieldId = Templatedictionary[7].Id;
                }
                if (metaField.FieldName.Contains("StringFormat") && metaField.MetaEntityId != null)
                {
                    metaField.ParentMetaFieldId = Templatedictionary[9].Id;
                }
                if (metaField.FieldName.Contains("RegularExpression") && metaField.MetaEntityId != null)
                {
                    metaField.ParentMetaFieldId = Templatedictionary[10].Id;
                }
                if (metaField.FieldName.Contains("CreationDate") || metaField.FieldName.Contains("LastUpdateDate")
                    && metaField.MetaEntityId != null)
                {
                    metaField.ParentMetaFieldId = Templatedictionary[8].Id;
                }
                if ((metaField.FieldName.Contains("IsReadOnly") || metaField.FieldName.Contains("IsVisible") ||
                     metaField.FieldName.Contains("IsResetOnCopy") || metaField.FieldName.Contains("IsRequired") ||
                     metaField.FieldName.Contains("IsDefaultValueNow") || metaField.FieldName.Contains("IsMasculine"))
                    && metaField.MetaEntityId != null)
                {
                    metaField.ParentMetaFieldId = Templatedictionary[12].Id;
                }
                if (metaField.FieldName.Contains("MinValue") || metaField.FieldName.Contains("MaxValue")
                    && metaField.MetaEntityId != null)
                {
                    metaField.ParentMetaFieldId = Templatedictionary[19].Id;
                }
                if (metaField.FieldName.Contains("MaxLength") || metaField.FieldName.Contains("MinLength")
                    || metaField.FieldName.Contains("Length") && metaField.MetaEntityId != null)
                {
                    metaField.ParentMetaFieldId = Templatedictionary[6].Id;
                }
                if (metaField.FieldName.Contains("Scale") && metaField.MetaEntityId != null)
                {
                    metaField.ParentMetaFieldId = Templatedictionary[23].Id;
                }
                if (metaField.FieldName.Contains("MetaEntity") && metaField.MetaEntityId != null)
                {
                    metaField.ParentMetaFieldId = Templatedictionary[24].Id;
                }
                if (metaField.FieldName.Contains("CreationUser") || metaField.FieldName.Contains("LastUpdateUser")
                    && metaField.MetaEntityId != null)
                {
                    metaField.ParentMetaFieldId = Templatedictionary[13].Id;
                }
            }
            context.SaveChanges();
        }
        #endregion
    }
}