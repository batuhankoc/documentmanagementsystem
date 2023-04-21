using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dms.Contract.DocumentContracts;
using dms.Contract.ResponseContracts;
using dms.Entity.Entity;

namespace dms.Service.Abstract
{
    public interface IDocumentService : IService<Document>
    {
        Task<ApiResponse<Document>> AddDocumentAsync(AddDocumentContract contract);
    }
}
