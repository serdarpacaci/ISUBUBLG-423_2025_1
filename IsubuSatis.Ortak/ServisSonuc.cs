﻿namespace IsubuSatis.Ortak
{
    public class ServisSonuc
    {
        public bool IsSuccess { get; set; }
        public ServisHataDto Error { get; set; }
    }

    public class ServisSonuc<T> : ServisSonuc
    {
        public T? Result { get; set; }

        public static ServisSonuc<T> Basarili(T data)
        {
            return new ServisSonuc<T>
            {
                IsSuccess = true,
                Result = data
            };
        }

        public static ServisSonuc<T> Hata(ServisHataDto problemDetails)
        {
            return new ServisSonuc<T>
            {
                IsSuccess = false,
                Error = problemDetails
                
            };
        }
    }
}

