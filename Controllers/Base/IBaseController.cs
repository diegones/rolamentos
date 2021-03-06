﻿using System.Collections.Generic;

namespace Controller.Base
{
    interface IBaseController<T> where T : class
    {
        void Incluir(T entity);
        IList<T> ListarTodos();

        IList<T> ListarPorNome(string nome);

        T BuscarPorID(int id);

        void Editar(T entity);

        void Excluir(int id);


    }
}