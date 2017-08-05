using System.Collections.Generic;
using System.Data.Entity.Migrations.Model;
using System.Data.Entity.Migrations.Sql;
using MySql.Data.Entity;

namespace HerefordSecuritiesLtd.Migrations
{
    /// <summary>
    /// This is a custom fix to a MySql bug.
    /// 
    /// https://stackoverflow.com/questions/28044340/table-dbname-dbo-tablename-doesnt-exist-entity-framework-6-with-mysql
    /// 
    /// When deleting a class form the Entity structure, the DROP functions caused errors decribed in the link above.
    /// The solution is also explained.
    /// 
    /// Summary: There is a need to remove ".dbo" from the generated DROP statements.
    /// 
    /// This occurs because the table names begin with dbo. in DropIndex or DropForeignKey statements. If you do
    ///
    ///Update-Database -Verbose
    ///you'll see the generated SQL &amp; the precise error message:
    ///
    ///Can't DROP 'FK_Bunnies_dbo.Carrots_Carrot_CarrotId'; check that column/key exists
    ///the actual FK name being
    ///
    ///FK_Bunnies_Carrots_Carrot_CarrotId
    ///It seems that the presence of the dbo. particle only affects DropIndex, DropForeignKey statements (I am running EF + MySQL). CreateIndex, AddForeignKey are not affected by this!
    ///
    ///So, the solution is to replace dbo. with nothing in ALL parameters passed to the aforementioned functions.
    /// </summary>
    public class CustomSqlGenerator : MySqlMigrationSqlGenerator
    {
        public override IEnumerable<MigrationStatement> Generate(IEnumerable<MigrationOperation> migrationOperations, string providerManifestToken)
        {
            IEnumerable<MigrationStatement> res = base.Generate(migrationOperations, providerManifestToken);
            foreach (MigrationStatement ms in res)
            {
                ms.Sql = ms.Sql.Replace("dbo.", "");
            }
            return res;
        }
    }
}