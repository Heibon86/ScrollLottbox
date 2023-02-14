using Configs;
using Core.Randomizer;
using Core.ScrollItem;
using UI;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private ScrollItemTable _scrollItemTable;
        [SerializeField] private ScrollItemPointsSource _pointsSource;
        [SerializeField] private PanelsController _panelsController;
        [SerializeField] private Camera _camera;
        [SerializeField] private ScrollItemSpawner _scrollItemSpawner;
    
        public override void InstallBindings()
        {
            Container.Bind<ScrollItemRandomizer>().AsCached().NonLazy();
            Container.Bind<Camera>().FromInstance(_camera).AsCached().NonLazy();
            Container.Bind<ScrollItemPointsSource>().FromInstance(_pointsSource).AsCached().NonLazy();
            Container.Bind<ScrollItemTable>().FromInstance(_scrollItemTable).AsCached().NonLazy();
            Container.Bind<ScrollItemSpawner>().FromInstance(_scrollItemSpawner).AsCached().NonLazy();
            Container.Bind<ScrollItemMover>().AsSingle().NonLazy();
            Container.Bind<PanelsController>().FromInstance(_panelsController).AsCached().NonLazy();
        }
    }
}
