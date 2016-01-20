using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Case3.PcSWinkelen.DAL.Mappings;
using Case3.PcSWinkelen.Entities;

namespace Case3.PcSWinkelen.DAL.Contexts
{
    /// <summary>
    ///  Class for connection to Winkelmand database
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class WinkelmandContext : DbContext
    {
        public WinkelmandContext() : base("PcSWinkelenDB")
        {
        }

        public DbSet<WinkelmandItem> WinkelmandItems { get; set; }

        /// <summary>
        /// Method which will be executed when the database models are created
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            if (modelBuilder != null)
            {
                modelBuilder.Configurations.Add<WinkelmandItem>(new WinkelmandItemMapping());
                base.OnModelCreating(modelBuilder);
            }
        }

        /// <summary>
        /// Override the SaveChanges method to catch the DbEntityValidationException
        /// </summary>
        /// <returns></returns>
        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                // Retrieve the error messages as a list of strings.
                var errorMessages = ex.EntityValidationErrors
                    .SelectMany(x => x.ValidationErrors)
                    .Select(x => x.ErrorMessage);

                // Join the list to a single string.
                var fullErrorMessage = string.Join("; ", errorMessages);

                // Combine the original exception message with the new one.
                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                // Throw a new DbEntityValidationException with the improved exception message.
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }
        }
    }
}
