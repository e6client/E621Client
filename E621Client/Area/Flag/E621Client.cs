﻿using Dawn;
using Flurl.Http;
using Flurl.Http.Content;
using Newtonsoft.Json.Linq;
using Noppes.E621.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Noppes.E621
{
    public partial class E621Client
    {
        public Task<IList<Flag>?> GetFlagsAsync(int postId) => GetFlagsAsync(new int[] { postId });
        public Task<IList<Flag>?> GetFlagsAsync(IEnumerable<int> postIds, int limit = 320)
        {
            Guard.Argument(limit, nameof(limit)).InRange(1, E621Constants.PostsMaximumLimit);

#pragma warning disable CS8619 // Nullability of reference types in value doesn't match target type.
#pragma warning disable CS8634 // The type cannot be used as type parameter in the generic type or method. Nullability of type argument doesn't match 'class' constraint.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8621 // Nullability of reference types in return type doesn't match the target delegate (possibly because of nullability attributes).
            return RequestAsync("/post_flags.json", request =>
                    request
                    .AuthenticatedIfPossible(this)
                    .SetQueryParam("limit", limit)
                    .SetQueryParam("search[post_id]", string.Join(',', postIds))
                    .GetJsonAsync(token => token.ToObject<IList<Flag>>()));
#pragma warning restore CS8621 // Nullability of reference types in return type doesn't match the target delegate (possibly because of nullability attributes).
#pragma warning restore CS8602 // Dereference of a possibly null reference.
#pragma warning restore CS8634 // The type cannot be used as type parameter in the generic type or method. Nullability of type argument doesn't match 'class' constraint.
#pragma warning restore CS8619 // Nullability of reference types in value doesn't match target type.
        }
    }
}