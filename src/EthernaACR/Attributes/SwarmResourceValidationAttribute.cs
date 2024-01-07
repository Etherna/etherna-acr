// Copyright 2021-present Etherna Sa
// 
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
// 
//       http://www.apache.org/licenses/LICENSE-2.0
// 
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.

using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Etherna.ACR.Attributes
{
    public sealed class SwarmResourceValidationAttribute : ValidationAttribute
    {
        private static readonly Regex SwarmResourceRegex = new("^[A-Fa-f0-9]{64}$");

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is string stringValue && SwarmResourceRegex.IsMatch(stringValue))
                return ValidationResult.Success;

            return new ValidationResult("Argument is not a valid swarm resource");
        }
    }
}
