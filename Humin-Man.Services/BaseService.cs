using Humin_Man.Common;
using Humin_Man.Common.Repository;
using Humin_Man.Common.Service;
using Microsoft.Extensions.Logging;
using System;

namespace Humin_Man.Services
{
    /// <summary>
    /// Class that implements <see cref="IBaseService"/>
    /// </summary>
    /// <seealso cref="Humin_Man.Common.Service.IBaseService" />
    public abstract class BaseService : IBaseService
    {
        private bool _disposed;

        /// <summary>
        /// Gets the unit of work.
        /// </summary>
        /// <value>
        /// The unit of work.
        /// </value>
        protected virtual IUnitOfWork UnitOfWork { get; }

        /// <summary>
        /// Gets the logger.
        /// </summary>
        /// <value>
        /// The logger.
        /// </value>
        protected virtual ILogger<BaseService> Logger { get; }

        /// <summary>
        /// Gets the user context.
        /// </summary>
        /// <value>
        /// The user context.
        /// </value>
        protected virtual IContext UserContext { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseService"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        /// <param name="logger">The logger.</param>
        /// <param name="userContext">The user context.</param>
        public BaseService(IUnitOfWork unitOfWork, ILogger<BaseService> logger, IContext userContext)
        {
            UnitOfWork = unitOfWork;
            Logger = logger;
            UserContext = userContext;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                _disposed = true;
                UnitOfWork.Dispose();
            }
        }
    }
}
