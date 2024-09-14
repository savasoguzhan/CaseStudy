using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.BusinessLayer.Abstract
{
    public interface IGenericService<T> where T : class
    {

        /// <summary>
        /// Inserts a new record.
        /// </summary>
        /// <param name="t">The object to be inserted.</param>
        void TInsert(T t);

        /// <summary>
        /// Updates an existing record.
        /// </summary>
        /// <param name="t">The object to be updated.</param>
        void TUpdate(T t);

        /// <summary>
        /// Deletes an existing record.
        /// </summary>
        /// <param name="t">The object to be deleted.</param>
        void TDelete(T t);


        /// <summary>
        /// Retrieves all records.
        /// </summary>
        /// <returns>A list of records.</returns>
        List<T> TGetAll();

        /// <summary>
        /// Retrieves a record by its id.
        /// </summary>
        /// <param name="id">The id of the record to be retrieved.</param>
        /// <returns>The requested record.</returns>
        T TGetById(int id);
    }
}
