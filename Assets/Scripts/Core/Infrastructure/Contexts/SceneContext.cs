using System.Collections.Generic;
using Core.Infrastructure.Installers.Scene;
using UnityEngine;
using VContainer;
using VContainer.Unity;


namespace Core.Infrastructure.Contexts
{
    public class SceneContext : LifetimeScope
    {
        [SerializeField] private List<MonoInstaller> sceneInstallers;
        [SerializeField] private LocalContainerPasserInstaller localContainerPasser;


        protected override void Awake()
        {
            base.Awake();
            autoRun = true;
        }


        protected override void Configure(IContainerBuilder builder)
        {
            if (!localContainerPasser)
            {
                Debug.LogError("LocalContainerPasserInstaller is not found");
            }
        
            sceneInstallers.Add(localContainerPasser);

            foreach (MonoInstaller installer in sceneInstallers)
            {
                installer.Install(builder);
            }
        }
    }
}
