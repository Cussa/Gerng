using System;
using GitExtensions.Gerng.Properties;
using GitUIPluginInterfaces;
using ResourceManager;
using System.ComponentModel.Composition;
using System.Diagnostics;
using System.IO;

namespace GitExtensions.Gerng
{
    /// <summary>
    /// A template for Git Extensions plugins.
    /// </summary>
    [Export(typeof(IGitPlugin))]
    public class Plugin : GitPluginBase
    {
        public const string PackageId = @"GitExtensions.Gerng";
        public const string PluginManagerRelativePath = @"HodStudio.Gerng\HodStudio.Gerng.UI.exe";

        public Plugin()
        {
            /// <summary>
            /// See: https://github.com/gitextensions/gitextensions.plugintemplate/wiki/GitPluginBase#protected-void-setnameanddescriptionstring-name
            /// </summary>
            Name = "Gerng";
            Description = "GE Release Notes Generator";

            /// <summary>
            /// See: https://github.com/gitextensions/gitextensions.plugintemplate/wiki/GitPluginBase#public-image-icon--get-protected-set-
            /// </summary>
            Icon = Resources.Icon;
        }


        /// <summary>
        /// See: https://github.com/gitextensions/gitextensions.plugintemplate/wiki/GitPluginBase#public-virtual-void-registerigituicommands-gituicommands
        /// </summary>
        public override void Register(IGitUICommands gitUiCommands)
        {
            
        }


        /// <summary>
        /// See: https://github.com/gitextensions/gitextensions.plugintemplate/wiki/GitPluginBase#public-virtual-void-unregisterigituicommands-gituicommands
        /// </summary>
        public override void Unregister(IGitUICommands gitUiCommands)
        {
            
        }


        /// <summary>
        /// See: https://github.com/gitextensions/gitextensions.plugintemplate/wiki/GitPluginBase#public-abstract-bool-executegituieventargs-args
        /// </summary>
        public override bool Execute(GitUIEventArgs gitUIEventArgs)
        {
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string pluginsPath = ManagedExtensibility.UserPluginsPath;

            ProcessStartInfo info = new ProcessStartInfo()
            {
                FileName = Path.Combine(pluginsPath, PackageId, PluginManagerRelativePath),
                Arguments = gitUIEventArgs.GitModule.WorkingDir,
                UseShellExecute = false,
            };
            Process.Start(info);

            return false;
        }
    }
}
