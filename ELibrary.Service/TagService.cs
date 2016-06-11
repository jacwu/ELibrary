using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ELibrary.Data;
using ELibrary.Model.Entities;

namespace ELibrary.Service
{
    public class TagService : ITagService
    {
        private ITagRepository tagRepository;
        public TagService(ITagRepository tagRepository)
        {
            this.tagRepository = tagRepository;
        }
    }
}
