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
        public void Should_Receive_Select_When_Tick()
        {
            // arrange // given
            GivenSelectKeyDown(true);
            // act // when
            TickPlayerController();
            // assert // then
            ShouldSelect();
        }

        [Test]
        public void Should_Did_Not_Receive_Select_When_Tick()
        {
            // arrange // given
            GivenSelectKeyDown(false);
            // act // when
            TickPlayerController();
            // assert // then
            DidNotSelect();
        }

        [Test]
        public void Should_Detect_Floor_When_Tick()
        {
            // arrange // given
            GivenSelectKeyDown(true);
            // act // when
            TickPlayerController();
            // assert // then
            ShouldSelect();
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

        private void GivenSelectKeyDown(bool keyDown)
        {
            inputReader.IsSelectKeyDown().Returns(keyDown);
        }

        private void TickPlayerController()
        {
            playerController.Tick();
        }

        private void ShouldSelect()
        {
            service.Received(1).Select();
        }

        private void DidNotSelect()
        {
            service.DidNotReceiveWithAnyArgs().Select();
        }

        #endregion
    }
}