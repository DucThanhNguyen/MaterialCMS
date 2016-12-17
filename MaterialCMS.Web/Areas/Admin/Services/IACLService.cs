using System.Collections.Generic;
using MaterialCMS.ACL;
using MaterialCMS.Models;
using MaterialCMS.Web.Areas.Admin.Models;

namespace MaterialCMS.Web.Areas.Admin.Services
{
    public interface IACLService
    {
        ACLModel GetACLModel();
        List<ACLRule> GetAllSystemRules();
        void UpdateACL(List<ACLUpdateRecord> model);
    }
}