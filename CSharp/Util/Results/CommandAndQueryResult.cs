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

using SystemEx.Util.Internal;
using System;
using System.Diagnostics;
using Resources = Util.Properties.Resources; 

namespace SystemEx.Util.Results
{
    /// <summary>
    /// The result of executing a Command which also returns a result (other than simple success/failure)
    /// The type is identical except in name to <see cref="QueryResult{TValue}"/> and exists only to make it more clear the origin of the result
    /// </summary>
    [Obsolete("violates command query seperation but is provided to allow for legacy code which has not yet attained that separation")]
    public static class CommandAndQueryResult
    {
        public static CommandAndQueryResult<TValue> Ok<TValue>(TValue value) => new CommandAndQueryResult<TValue>(value, true, string.Empty, null);
        public static CommandAndQueryResult<TValue> Failed<TValue>(string reason, Exception? cause = null) => 
            new CommandAndQueryResult<TValue>(default!, false, reason, cause); // allow default, which may be null in this case as it is a failure anyway and we shouldn't be accessing the value
    }

    [DebuggerDisplay("{Value} {Success} {Reason}")]
    public struct CommandAndQueryResult<TValue> : IEquatable<CommandAndQueryResult<TValue>>
    {
        internal CommandAndQueryResult(TValue value, bool success, string reason, Exception? cause)
        {
            ValueResult = new ValueResultCore<TValue>(value, success, reason, cause);
        }

        /// <summary>Resulting Value of the Query</summary>
        /// <exception cref="InvalidOperationException">thrown if <see cref="Success"/> is <c>false</c></exception>
        public TValue Value => Success ? ValueResult.Value : throw new InvalidOperationException(Resources.InvalidQueryResultValueAccess);
        /// <summary>The result of the operation</summary>
        public bool Success => ValueResult.Success;
        /// <summary>The reason for failure, only meaningful if <see cref="Success"/> is <c>false</c></summary>
        public string Reason => ValueResult.Reason;
        /// <summary>Exceptional cause of the failure, only meaningful if <see cref="Success"/> is <c>false</c></summary>
        public Exception? Cause => ValueResult.Cause;
        public bool ToBoolean() => Success;

        public static bool operator==(CommandAndQueryResult<TValue> leftHandSide, CommandAndQueryResult<TValue> rightHandSide) => leftHandSide.Equals(rightHandSide);
        public static bool operator!=(CommandAndQueryResult<TValue> leftHandSide, CommandAndQueryResult<TValue> rightHandSide) => !(leftHandSide == rightHandSide);
        public static implicit operator bool(CommandAndQueryResult<TValue> result) => result.ToBoolean();
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CA2225:Operator overloads have named alternates", Justification = "Provided by Value property")]
        public static explicit operator TValue(CommandAndQueryResult<TValue> result) => result.Value;

        private ValueResultCore<TValue> ValueResult { get; }

        #region ValueType

        public override bool Equals(object? obj) => obj is CommandAndQueryResult<TValue> rightHandSide ? Equals(rightHandSide) : false;
        public override int GetHashCode() => ValueResult.GetHashCode();

        #endregion
        #region IEquatable{QueryResult{TValue}}
        public bool Equals(CommandAndQueryResult<TValue> other) =>
            ValueResult.Equals(other.ValueResult);
        #endregion
    }
}
