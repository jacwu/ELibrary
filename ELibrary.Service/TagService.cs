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
        private IEnumerable<Tag> _allTags;
        public TagService(ITagRepository tagRepository)
        {
            this.tagRepository = tagRepository;
        }

        public IEnumerable<Tag> AllTags
        {
            get
            {
                if(null == _allTags)
                {
                    _allTags = this.tagRepository.GetAll();
                }
                return _allTags;
            }
        }

        public Tag GetTag(int id)
        {
            return tagRepository.GetTagWithBooks(id, true);
        }

        public IEnumerable<Tag> GetTagsForBook(int bookId)
        {
            return tagRepository.GetTagsForBook(bookId);
        }
    }
}
