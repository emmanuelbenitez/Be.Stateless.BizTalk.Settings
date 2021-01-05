#region Copyright & License

// Copyright © 2012 - 2021 François Chabot
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
// http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

#endregion

using System;
using System.Diagnostics.CodeAnalysis;

namespace Be.Stateless.BizTalk.Settings
{
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    public abstract class SupportApplicationSettingsOverrideCommandBase : IDisposable
    {
        #region IDisposable Members

        [SuppressMessage("Design", "CA1063:Implement IDisposable Correctly")]
        public void Dispose()
        {
            CleanUpApplicationSettingsContext();
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

        public Type ApplicationSettingsOverrideType { get; set; }

        protected internal void SetUpApplicationSettingsContext()
        {
            if (ApplicationSettingsOverrideType != null)
                ApplicationSettingsOverrideContext.Current = (IApplicationSettings) Activator.CreateInstance(ApplicationSettingsOverrideType);
        }

        private void CleanUpApplicationSettingsContext()
        {
            if (ApplicationSettingsOverrideType != null) ApplicationSettingsOverrideContext.Current = null;
        }

        protected virtual void Dispose(bool disposing) { }


    }
}
