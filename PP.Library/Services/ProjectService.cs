using Newtonsoft.Json;
using PP.Library.DTO;
using PP.Library.Models;
using PP.Library.Utilities;
using PP.Library.
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP.Library.Services
{
    public class ProjectService
    {
        private List<ProjectDTO> projects;
        public List<ProjectDTO> Projects
        {
            get
            {
                return projects;
            }
        }

        private static ProjectService? instance;
        public static ProjectService Current
        {
            get
            {
                if(instance == null)
                {
                    instance = new ProjectService();
                }

                return instance;
            }
        }

        private ProjectService()
        {
            //projects = new List<Project> { 
            //    new Project { Id = 1, Name = "Test Project", ClientId = 1 } 
            //};
        }

        public ProjectDTO? Get(int id)
        {
            return Projects.FirstOrDefault(p => p.Id == id);
        }

        public void AddOrUpdate(Project project)
        {
            var isAdding = false;
            if(project.Id == 0)
            {
                isAdding = true;
            }

            var response = new WebRequestHandler().Post("Project", project).Result;
            var projectFromService = JsonConvert.DeserializeObject<ProjectDTO>(response);
            if (isAdding && projectFromService != null)
            {
                projects.Add(projectFromService);
            } else
            {
                if(projectFromService == null)
                {
                    return;
                }
                var existingDTO = projects.FirstOrDefault(p => p.Id == projectFromService.Id);
                projects.Remove(existingDTO);
                projects.Add(projectFromService);
            }
        }

        private int LastId
        {
            get
            {
                return Projects.Any() ? Projects.Select(c => c.Id).Max() : 0;
            }
        }
    }
}
