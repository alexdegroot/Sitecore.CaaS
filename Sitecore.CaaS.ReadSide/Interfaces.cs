using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

// Please largely ignore this file, it was to map out the original idea but this is a silly abstraction too much bound to the original dataprovider
// Some stuff might still work for the retrieval part

namespace Sitecore.CaaS.ReadSide
{
    public interface IReadProperty
    {
        Task<string> GetPropertyAsync(string propertyName);
    }

    public interface IManipulateProperty
    {
        Task<bool> SetPropertyAsync(string propertyName, string propertyValue);
        Task<bool> DeletePropertyAsync(string propertyName);
    }

    public interface IReadItem
    {
        Task<MicroItem> GetItemDefinitionAsync(Guid id);
        Task<MicroItem> GetItemFieldsAsync(Guid id, string language, string version);
        Task<IEnumerable<MicroItem>> GetItemVersionsAsync(Guid id);
        Task<IOrderedEnumerable<Guid>> ResolvePathAsync(string path, char seperator);
    }

    public interface IQueryItemSpecific
    {
        [Obsolete("Sitecore Query not supported", true)]
        Task<MicroItem> SelectIDsAsync(string query);

        [Obsolete("Sitecore Query not supported", true)]
        Task<MicroItem> SelectSingleIdAsync(string query);

        Task<IEnumerable<MicroItem>> GetTemplatesAsync();
        Task<IEnumerable<MicroItem>> GetByTemplateAsync(Guid templateId);
        Task<IEnumerable<MicroItem>> GetByWorkflowState(Guid workflow, Guid workflowState);
    }
    public interface IQueryItem { 

        Task<IEnumerable<MicroItem>> SelectAsync(Func<MicroItem, bool> predicate);
        Task<MicroItem> SingleAsync(Func<MicroItem, bool> predicate);
    }

    public interface IManipulateItem
    {
        Task<bool> CreateItemAsync();
        Task<bool> AddVersionAsync();
        Task<bool> CopyItemAsync(Guid source, Guid destination, string copyName, Guid copyId);
        Task<bool> DeleteItemAsync(Guid guid);
        Task<bool> RemoveVersionAsync(Guid guid, string language, string version);
        Task<bool> RemoveVersionsAsync(Guid guid, string language, bool removeSharedData);
        Task<bool> SaveItemAsync(MicroItem microItem);
        Task<bool> ChangeTemplateAsync(Guid id, Guid templateId);
    }

    public interface IReadItemRelation
    {
        Task<IEnumerable<Guid>> GetChildIDsAsync(Guid id);
        Task<Guid> GetParentIdAsync(Guid id);
        Task<Guid> GetRootIdAsync();
        Task<bool> HasChildrenAsync(Guid id);
    }

    public interface IManipulateItemRelation
    {
        Task<bool> ChangeParentIdAsync(Guid id, Guid newParentId);
    }

    public interface IReadBlob
    {
        Task<bool> BlobExists(Guid id);
        Task<Stream> GetBlobAsync(Guid id);
    }

    public interface IManipulateBlob
    {
        Task<bool> SetBlobAsync(Guid id, Stream stream);
    }

}
