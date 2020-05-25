﻿//
// Copyright © 2020 Terry Moreland
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), 
// to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, 
// and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, 
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, 
// WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
// 

using System.Runtime.CompilerServices;

namespace System.Util.Extensions
{
    public static class NullableExtensions
    {
        /// <summary>Returns true if <paramref name="value"/> is non-null</summary>
        public static bool HasValue<TValue>(this TValue? value) where TValue : class => value != null;

        /// <summary>Returns true if <paramref name="value"/> is non-null</summary>
        public static bool HasValue<TValue>(this TValue? value) where TValue : struct => value != null;

        /// <summary>simple wrapper around null coallese operator for improved readability</summary>
        /// <typeparam name="TValue">nullable class type</typeparam>
        /// <param name="value">value to return if non-null</param>
        /// <param name="or">alternate value which should not be null</param>
        /// <returns><paramref name="value"/> if non-null; otherwise, <paramref name="or"/></returns>
        /// <remarks>no null check is performed on <paramref name="or"/> so null may still be returned if that value is null</remarks>
        public static TValue OrElse<TValue>(this TValue? value, TValue or) where TValue : class => value ?? or;

        /// <summary>simple wrapper around null coallese operator for improved readability</summary>
        /// <typeparam name="TValue">nullable value type</typeparam>
        /// <param name="value">value to return if non-null</param>
        /// <param name="or">alternate value which should not be null</param>
        /// <returns><paramref name="value"/> if non-null; otherwise, <paramref name="or"/></returns>
        /// <remarks>no null check is performed on <paramref name="or"/> so null may still be returned if that value is null</remarks>
        public static TValue OrElse<TValue>(this TValue? value, TValue or) where TValue : struct => value ?? or;

        /// <summary>
        /// returns <paramref name="value"/> or value provided by <paramref name="supplier"/>
        /// </summary>
        /// <exception cref="ArgumentNullException">if <paramref name="supplier"/> is null if <paramref name="value"/> is not</exception>
        public static TValue OrElseGet<TValue>(this TValue? value, Func<TValue> supplier) where TValue : class
        {
            if (value != null)
                return value;
            if (supplier == null)
                throw new ArgumentNullException(nameof(supplier));
            return supplier.Invoke();
        }
        /// <summary>
        /// returns <paramref name="value"/> or value provided by <paramref name="supplier"/>
        /// </summary>
        /// <exception cref="ArgumentNullException">if <paramref name="supplier"/> is null if <paramref name="value"/> is not</exception>
        public static TValue OrElseGet<TValue>(this TValue? value, Func<TValue> supplier) where TValue : struct
        {
            if (value != null)
                return (TValue)value;
            if (supplier == null)
                throw new ArgumentNullException(nameof(supplier));
            return supplier.Invoke();
        }

        /// <summary>
        /// returns <paramref name="value"/> if non-null or throws exception of type <typeparamref name="TException"/>
        /// using provided arguments
        /// </summary>
        /// <typeparam name="TValue">nullable type of value</typeparam>
        /// <typeparam name="TException">type of exception to throw if <paramref name="value"/> is null</typeparam>
        /// <param name="value">value to return if non-null</param>
        /// <param name="exceptionArguments">passed to constructor of <typeparamref name="TException"/></param>
        /// <returns>value if non-null</returns>
        /// <exception><typeparamref name="TException"/> if <paramref name="value"/> is null</exception>
        public static TValue OrElseThrow<TValue, TException>(this TValue? value, params object[] exceptionArguments) 
            where TValue : class
            where TException : Exception
        {
            if (value != null)
                return value;

            return ThrowException<TValue, TException>(exceptionArguments);
        }

        /// <summary>
        /// returns <paramref name="value"/> if non-null or throws exception of type <typeparamref name="TException"/>
        /// using provided arguments
        /// </summary>
        /// <typeparam name="TValue">nullable type of value</typeparam>
        /// <typeparam name="TException">type of exception to throw if <paramref name="value"/> is null</typeparam>
        /// <param name="value">value to return if non-null</param>
        /// <param name="exceptionArguments">passed to constructor of <typeparamref name="TException"/></param>
        /// <returns>value if non-null</returns>
        /// <exception><typeparamref name="TException"/> if <paramref name="value"/> is null</exception>
        public static TValue OrElseThrow<TValue, TException>(this TValue? value, params object[] exceptionArguments) 
            where TValue : struct
            where TException : Exception
        {
            if (value != null)
                return (TValue)value;

            return ThrowException<TValue, TException>(exceptionArguments);
        }

        /// <summary>
        /// returns <paramref name="value"/> if non-null or throws exception provided by <paramref name="exceptionSuppliier"/>
        /// </summary>
        public static TValue OrElseThrow<TValue>(this TValue? value, Func<Exception> exceptionSuppliier) where TValue : class
        {
            if (value != null)
                return value;
            throw exceptionSuppliier?.Invoke() ?? throw new ArgumentNullException(nameof(exceptionSuppliier));
        }

        /// <summary>
        /// returns <paramref name="value"/> if non-null or throws exception provided by <paramref name="exceptionSuppliier"/>
        /// </summary>
        public static TValue OrElseThrow<TValue>(this TValue? value, Func<Exception> exceptionSuppliier) where TValue : struct
        {
            if (value != null)
                return (TValue)value;
            throw exceptionSuppliier?.Invoke() ?? throw new ArgumentNullException(nameof(exceptionSuppliier));
        }

        private static TValue ThrowException<TValue, TException>(params object[] arguments)
            where TException : Exception
        {
            var exception = (Exception?)Activator.CreateInstance(typeof(TException), arguments);
            throw exception.OrElse<Exception>(new NullReferenceException());
        }
    }
}
