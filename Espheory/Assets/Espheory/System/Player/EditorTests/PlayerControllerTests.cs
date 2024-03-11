#region

using NSubstitute;
using NUnit.Framework;
using Zenject;

#endregion

namespace Espheory.System.Player
{
    public class PlayerControllerTests : ZenjectUnitTestFixture
    {
        #region Private Variables

        private IInputReader     inputReader;
        private IActionService   service;
        private PlayerController playerController;

        #endregion

        #region Test Methods

        [Test]
        public void Should_Call_Select_When_Tick()
        {
            // arrange // given
            Given_SelectKeyDown(true);
            // act // when
            Tick_PlayerController();
            // assert // then
            Should_Select();
        }

        #endregion

        #region Public Methods

        public override void Setup()
        {
            base.Setup();

            Container.Bind<IInputReader>().FromSubstitute().AsSingle();
            Container.Bind<IActionService>().FromSubstitute().AsSingle();
            Container.Bind<PlayerController>().AsSingle();

            inputReader      = Container.Resolve<IInputReader>();
            service          = Container.Resolve<IActionService>();
            playerController = Container.Resolve<PlayerController>();
        }

        #endregion


        #region Private Methods

        private void Given_SelectKeyDown(bool keyDown)
        {
            inputReader.IsSelectKeyDown().Returns(keyDown);
        }

        private void Should_Select()
        {
            service.Received(1).Select();
        }

        private void Tick_PlayerController()
        {
            playerController.Tick();
        }

        #endregion
    }
}