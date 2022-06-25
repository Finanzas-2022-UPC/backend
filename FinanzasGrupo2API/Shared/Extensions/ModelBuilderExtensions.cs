using Microsoft.EntityFrameworkCore;

namespace FinanzasGrupo2API.Shared.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void UseSnakeCaseNamingConvention(this ModelBuilder builder)
        {
            //Apply Naming Convention for Each Entity

            foreach (var entity in builder.Model.GetEntityTypes())
            {
                entity.SetTableName(StringExtensions.ToSnakeCase(entity.GetTableName()));

                //foreach (var property in entity.GetProperties())
                //    property.SetColumnName(StringExtensions.ToSnakeCase(property.GetColumnName()));

                foreach (var key in entity.GetKeys()) key.SetName(StringExtensions.ToSnakeCase(key.GetName()));

                foreach (var foreignKey in entity.GetForeignKeys())
                    foreignKey.SetConstraintName(StringExtensions.ToSnakeCase(foreignKey.GetConstraintName()));

                foreach (var index in entity.GetIndexes()) index.SetDatabaseName(StringExtensions.ToSnakeCase(index.GetDatabaseName()));
            }
        }
    }
}
