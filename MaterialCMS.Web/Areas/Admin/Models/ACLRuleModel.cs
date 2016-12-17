using System.Collections.Generic;
using System.Linq;
using MaterialCMS.ACL;
using MaterialCMS.Models;

namespace MaterialCMS.Web.Areas.Admin.Models
{
    public class ACLRuleModel
    {
        public static ACLRuleModel Create(List<ACLRoleModel> roles, ACLRule rule, ACLGroup group)
        {
            return new ACLRuleModel
                       {
                           Name = group.Name,
                           AppName = group.AppName,
                           Operations = group.Operations.Select(operation => ACLRuleOperationModel.Create(roles, rule, operation, group.Type)).ToList()
                       };
        }

        private ACLRuleModel()
        {

        }
        public string Name { get; private set; }
        public string AppName { get; private set; }
        public List<ACLRuleOperationModel> Operations { get; private set; }
    }
}