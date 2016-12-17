using System;
using System.Collections.Generic;
using System.Linq;
using MaterialCMS.ACL;
using MaterialCMS.Models;

namespace MaterialCMS.Web.Areas.Admin.Models
{
    public class ACLRuleOperationModel
    {
        public static ACLRuleOperationModel Create(List<ACLRoleModel> roles, ACLRule rule, ACLOperation operation, Type type)
        {
            return new ACLRuleOperationModel
                       {
                           DisplayName = operation.Name,
                           Key = operation.Key,
                           Roles = roles.Select(role => ACLAvailableModel.Create(role, rule, operation.Name, type)).ToList()
                       };
        }

        private ACLRuleOperationModel()
        {

        }
        public string DisplayName { get; private set; }
        public List<ACLAvailableModel> Roles { get; private set; }
        public string Key { get; private set; }
    }
}