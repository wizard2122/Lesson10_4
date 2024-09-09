using System;

public class SceneLoader : ISimpleSceneLoader, ILevelLoader
{
    private readonly ZenjectSceneLoaderWrapper _zenjectSceneLoader;

    public SceneLoader(ZenjectSceneLoaderWrapper zenjectSceneLoader)
    {
        _zenjectSceneLoader = zenjectSceneLoader;
    }

    public void Load(SceneID sceneID)
    {
        if (sceneID == SceneID.GameplayLevel)
            throw new ArgumentException($"{SceneID.GameplayLevel} cannot be started without configuration, use ILevelLoader");

        _zenjectSceneLoader.Load(null, (int)sceneID);
    }

    public void Load(LevelLoadingData levelLoadingData)
    {
        _zenjectSceneLoader.Load(container =>
        {
            container.BindInstance(levelLoadingData);
        }, (int)SceneID.GameplayLevel);
    }
}
