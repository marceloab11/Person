﻿namespace PersonTable.Banco
{
    public class Dal<T> where T : class
    {
        private readonly PersonContext context;

        public Dal(PersonContext context)
        {
            this.context = context; 
        }

        public IEnumerable<T> Listar()
        {
            return context.Set<T>().ToList();
        }

        public void Adicionar(T objeto)
        {
            context.Set<T>().Add(objeto);
            context.SaveChanges();
        }

        public void Atualizar(T objeto)
        {
            context.Set<T>().Update(objeto);
            context.SaveChanges();
        }

        public void Delete(T objeto)
        {
            context.Set<T>().Remove(objeto);
            context.SaveChanges();
        }

        public T? RecuperarPor(Func<T, bool> condicao)
        {
            return context.Set<T>().FirstOrDefault(condicao);
        }

        public IEnumerable<T> ListarPor(Func<T, bool> condicao)
        {
            return context.Set<T>().Where(condicao);
        }
    }
}