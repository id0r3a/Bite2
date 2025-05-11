using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.DTOs.MediatR
{
    // Generiskt resultat med data
    public class OperationResult<T>
    {
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
        public T? Data { get; set; }

        //Skapa ett lyckat resultat (med data + valfri message)
        public static OperationResult<T> Success(T data, string? message = null)
        {
            return new OperationResult<T>
            {
                IsSuccess = true,
                Data = data,
                Message = message
            };
        }

        //Skapa ett misslyckat resultat (med felmeddelande)
        public static OperationResult<T> Failure(string errorMessage)
        {
            return new OperationResult<T>
            {
                IsSuccess = false,
                Message = errorMessage
            };
        }
    }

    //Resultat utan data
    public class OperationResult
    {
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }

        //Lyckat utan data + valfri message
        public static OperationResult Success(string? message = null)
        {
            return new OperationResult
            {
                IsSuccess = true,
                Message = message
            };
        }

        //Misslyckat utan data
        public static OperationResult Failure(string errorMessage)
        {
            return new OperationResult
            {
                IsSuccess = false,
                Message = errorMessage
            };
        }
    }
}
