﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wissen.Istka.BlogProject.App.Entity.Repositories;

namespace Wissen.Istka.BlogProject.App.Entity.UnitOfWorks
{
	public interface IUnitOfWork : IDisposable
	{
		IRepository<T> GetRepository<T>() where T : class, new();

		void Commit();		//içine SaveChanges();
		Task CommitAsync();
	}
}
