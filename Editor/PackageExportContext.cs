namespace StansAssets.PackageExport.Editor
{
    /// <summary>
    /// Package Export Context.
    /// </summary>
    public class PackageExportContext
    {
        string m_Destination;

        /// <summary>
        /// If set to <c>true</c> package version postfix is added. Example: <c>MyAwesomeAsset_v3.2.unitypackage</c>
        /// </summary>
        public bool AddPackageVersionPostfix { get; set; }

        internal string[] ExcludedPaths { get; private set; }

        /// <summary>
        /// Creates Package Export Context.
        /// </summary>
        /// <param name="name">Exported <c>.unitypackage</c> name. For example: <c>MyAwesomeAsset</c>.</param>
        /// <param name="destination">The <c>*.unitypackage</c> install destination. For example: <c>Assets/Plugins/StansAssets</c>.</param>
        public PackageExportContext(string name, string destination)
        {
            m_Destination = destination;
        }

        /// <summary>
        /// Use to set export excluded paths.
        /// </summary>
        /// <param name="excludedPaths">Package relative excluded paths list</param>
        public void SetExcludedPaths(params string[] excludedPaths)
        {
            ExcludedPaths = excludedPaths;
        }
    }
}
