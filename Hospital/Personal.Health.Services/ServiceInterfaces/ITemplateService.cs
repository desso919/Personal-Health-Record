using Personal.Health.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal.Health.Services.ServiceInterfaces
{
    public interface ITemplateService
    {
        Template GetTemplate(long id);

        List<Template> GetAllPatientTemplates(long patient_id);

        bool AddTemplate(Template template);
    }
}
