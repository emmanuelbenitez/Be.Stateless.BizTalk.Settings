#region Copyright & License

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
using FluentAssertions;
using Xunit;

namespace Be.Stateless.BizTalk.Settings
{
    public class ApplicationSettingsMementoFixture : IDisposable
    {
        [Fact]
        public void GetApplicationSettings()
        {
            var applicationSettings = new DummyApplicationSettings();
            var memento = new ApplicationSettingsMemento<DummyApplicationSettings>(applicationSettings);
            memento.ApplicationSettings.Should().Be(applicationSettings);
        }

        [Fact]
        public void GetApplicationSettingsOverride()
        {
            var memento = new ApplicationSettingsMemento<DummyApplicationSettings>(new DummyApplicationSettings());
            ApplicationSettingsOverrideContext.Current = new DummyApplicationSettings();
            memento.ApplicationSettings.Should().Be(ApplicationSettingsOverrideContext.Current);
        }

        public void Dispose()
        {
            ApplicationSettingsOverrideContext.Current = null;
        }
    }
}
