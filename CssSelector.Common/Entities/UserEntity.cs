using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CssSelector.Common.Attributes;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CssSelector.Common.Entities
{
    public class UserEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonIgnoreIfNull]
        public string Id { get; set; }

        [UserUnique]
        public string Email { get; set; }
        public string PasswordHash { get; set; }
    }
}