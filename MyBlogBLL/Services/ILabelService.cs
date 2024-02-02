using MyBlogDAL.Repositories.Abstract;
using MyBlogDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Label = MyBlogDomain.Entities.Label;

namespace MyBlogBLL.Services
{
    public class ILabelService
    {

        private readonly ILabelRepository labelRepository;

        public ILabelService(ILabelRepository labelRepository)
        {
            this.labelRepository = labelRepository;
        }

        public List<Label> GetAllLabels()
        {
            return labelRepository.GetAll().ToList();
        }

        public Label GetLabelById(int id)
        {
            return labelRepository.GetById(id);
        }

        public bool AddLabel(Label label)
        {
            return labelRepository.Add(label);
        }

        public bool UpdateLabel(Label label)
        {
            return labelRepository.Update(label);   
        }

        public bool RemoveLabel(Label label)
        {
            return labelRepository.Delete(label);
        }

    }
}
