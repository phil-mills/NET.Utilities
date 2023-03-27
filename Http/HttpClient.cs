namespace NET.Utilities.Http
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    public class HttpClient : System.Net.Http.HttpClient
    {
        public int MaxRetries { get; set; } = 5;

        public int TimeoutDuration { get; set; } = 500;

        public List<HttpStatusCode> TransientErrorCodes { get; set; } = new List<HttpStatusCode> 
        {
            HttpStatusCode.RequestTimeout,
            HttpStatusCode.GatewayTimeout
        };

        public new async Task<HttpResponseMessage> PostAsync(Uri requestUri, HttpContent content)
        {
            return await this.RetryAsync(async () => 
            {
                return await base.PostAsync(requestUri, content);
            });
        }

        public new async Task<HttpResponseMessage> PostAsync(Uri requestUri, HttpContent content, CancellationToken cancellationToken)
        {
            return await this.RetryAsync(async () => 
            {
                return await base.PostAsync(requestUri, content, cancellationToken);
            });
        }

        public new async Task<HttpResponseMessage> PostAsync(string requestUri, HttpContent content)
        {
            return await this.RetryAsync(async () => 
            {
                return await base.PostAsync(requestUri, content);
            });
        }

        public new async Task<HttpResponseMessage> PostAsync(string requestUri, HttpContent content, CancellationToken cancellationToken)
        {
            return await this.RetryAsync(async () => 
            {
                return await base.PostAsync(requestUri, content, cancellationToken);
            });
        }

        public new async Task<HttpResponseMessage> PatchAsync(Uri requestUri, HttpContent content)
        {
            return await this.RetryAsync(async () => 
            {
                return await base.PatchAsync(requestUri, content);
            });
        }

        public new async Task<HttpResponseMessage> PatchAsync(Uri requestUri, HttpContent content, CancellationToken cancellationToken)
        {
            return await this.RetryAsync(async () => 
            {
                return await base.PatchAsync(requestUri, content, cancellationToken);
            });
        }

        public new async Task<HttpResponseMessage> PatchAsync(string requestUri, HttpContent content)
        {
            return await this.RetryAsync(async () => 
            {
                return await base.PatchAsync(requestUri, content);
            });
        }

        public new async Task<HttpResponseMessage> PatchAsync(string requestUri, HttpContent content, CancellationToken cancellationToken)
        {
            return await this.RetryAsync(async () => 
            {
                return await base.PatchAsync(requestUri, content, cancellationToken);
            });
        }

        public new async Task<HttpResponseMessage> PutAsync(Uri requestUri, HttpContent content)
        {
            return await this.RetryAsync(async () => 
            {
                return await base.PutAsync(requestUri, content);
            });
        }

        public new async Task<HttpResponseMessage> PutAsync(Uri requestUri, HttpContent content, CancellationToken cancellationToken)
        {
            return await this.RetryAsync(async () => 
            {
                return await base.PutAsync(requestUri, content, cancellationToken);
            });
        }

        public new async Task<HttpResponseMessage> PutAsync(string requestUri, HttpContent content)
        {
            return await this.RetryAsync(async () => 
            {
                return await base.PutAsync(requestUri, content);
            });
        }

        public new async Task<HttpResponseMessage> PutAsync(string requestUri, HttpContent content, CancellationToken cancellationToken)
        {
            return await this.RetryAsync(async () => 
            {
                return await base.PutAsync(requestUri, content, cancellationToken);
            });
        }

        public new async Task<HttpResponseMessage> GetAsync(Uri requestUri)
        {
            return await this.RetryAsync(async () => 
            {
                return await base.GetAsync(requestUri);
            });
        }

        public new async Task<HttpResponseMessage> GetAsync(Uri requestUri, CancellationToken cancellationToken)
        {
            return await this.RetryAsync(async () => 
            {
                return await base.GetAsync(requestUri, cancellationToken);
            });
        }

        public new async Task<HttpResponseMessage> GetAsync(Uri requestUri, HttpCompletionOption completionOption)
        {
            return await this.RetryAsync(async () => 
            {
                return await base.GetAsync(requestUri, completionOption);
            });
        }

        public new async Task<HttpResponseMessage> GetAsync(Uri requestUri, HttpCompletionOption completionOption, CancellationToken cancellationToken)
        {
            return await this.RetryAsync(async () => 
            {
                return await base.GetAsync(requestUri, completionOption, cancellationToken);
            });
        }

        public new async Task<HttpResponseMessage> GetAsync(string requestUri)
        {
            return await this.RetryAsync(async () => 
            {
                return await base.GetAsync(requestUri);
            });
        }

        public new async Task<HttpResponseMessage> GetAsync(string requestUri, HttpCompletionOption completionOption)
        {
            return await this.RetryAsync(async () => 
            {
                return await base.GetAsync(requestUri, completionOption);
            });
        }

        public new async Task<HttpResponseMessage> GetAsync(string requestUri, CancellationToken cancellationToken)
        {
            return await this.RetryAsync(async () => 
            {
                return await base.GetAsync(requestUri, cancellationToken);
            });
        }

        public new async Task<HttpResponseMessage> GetAsync(string requestUri, HttpCompletionOption completionOption, CancellationToken cancellationToken)
        {
            return await this.RetryAsync(async () => 
            {
                return await base.GetAsync(requestUri, completionOption, cancellationToken);
            });
        }

        public new async Task<HttpResponseMessage> DeleteAsync(Uri requestUri)
        {
            return await this.RetryAsync(async () => 
            {
                return await base.DeleteAsync(requestUri);
            });
        }

        public new async Task<HttpResponseMessage> DeleteAsync(Uri requestUri, CancellationToken cancellationToken)
        {
            return await this.RetryAsync(async () => 
            {
                return await base.DeleteAsync(requestUri, cancellationToken);
            });
        }

        public new async Task<HttpResponseMessage> DeleteAsync(string requestUri)
        {
            return await this.RetryAsync(async () => 
            {
                return await base.DeleteAsync(requestUri);
            });
        }

        public new async Task<HttpResponseMessage> DeleteAsync(string requestUri, CancellationToken cancellationToken)
        {
            return await this.RetryAsync(async () => 
            {
                return await base.DeleteAsync(requestUri, cancellationToken);
            });
        }

        private async Task<HttpResponseMessage> RetryAsync(Func<Task<HttpResponseMessage>> block)
        {
            var retries = 0;

            HttpResponseMessage result = null;

            while (retries++ < MaxRetries)
            {
                result = await block();

                if (!this.TransientErrorCodes.Contains(result.StatusCode))
                {
                    return result;
                }

                await Task.Delay(TimeoutDuration);
            }

            return result;
        }
    }
}