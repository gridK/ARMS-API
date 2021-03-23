using System;
namespace AUroomAPI.Interfaces
{
    public interface IExceptionManager
    {
        bool IsDuplicatedEntityCode(Exception e);
    }
}