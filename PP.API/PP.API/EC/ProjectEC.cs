using PP.API.Database;
using PP.Library.DTO;
using PP.Library.Models;

namespace PP.API.EC
{
    public class ProjectEC
    {
        public ProjectDTO? AddOrUpdate(ProjectDTO dto)
        {

            if (dto.Id <= 0)
            {
                dto.Id = FakeDatabase.LastClientId + 1;
                FakeDatabase.Projects.Add(new Project(dto));
            }
            else
            {
                var projToUpdate = FakeDatabase.Projects.FirstOrDefault(c => c.Id == dto.Id);
                if (projToUpdate != null)
                {
                    FakeDatabase.Projects.Remove(projToUpdate);
                    FakeDatabase.Projects.Add(new Project(dto));
                }

            }

            var returnVal = FakeDatabase.Projects.FirstOrDefault(p => p.Id == dto.Id);
            if (returnVal != null)
            {

                return new ProjectDTO(returnVal);
            }
            return null;
        }
        
        public IEnumerable<ProjectDTO> GetAll()
        {
            return FakeDatabase.Projects.Select(p => new ProjectDTO(p)).Take(100);
        }
    }
}
