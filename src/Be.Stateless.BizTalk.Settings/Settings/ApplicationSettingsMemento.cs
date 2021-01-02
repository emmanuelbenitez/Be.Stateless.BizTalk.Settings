﻿#region Copyright & License

// Copyright © 2012 - 2020 François Chabot
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

namespace Be.Stateless.BizTalk.Settings
{
    public sealed class ApplicationSettingsMemento<TApplicationSettings>
        where TApplicationSettings : IApplicationSettings
    {
        public ApplicationSettingsMemento(TApplicationSettings defaultApplicationSettings)
        {
            _defaultApplicationSettings = defaultApplicationSettings ?? throw new ArgumentNullException(nameof(defaultApplicationSettings));
        }

        public TApplicationSettings ApplicationSettings => (TApplicationSettings) (ApplicationSettingsOverrideContext.Current != null
            ? ApplicationSettingsOverrideContext.Current
            : _defaultApplicationSettings);

        private readonly TApplicationSettings _defaultApplicationSettings;
    }
}
