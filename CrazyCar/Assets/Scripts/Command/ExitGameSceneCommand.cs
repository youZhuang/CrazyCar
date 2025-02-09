﻿using LitJson;
using System.Text;
using UnityEngine;
using QFramework;
using Utils;

public class ExitGameSceneCommand : AbstractCommand
{
    protected override void OnExecute()
    {
        Time.timeScale = 0;
        this.SendCommand(new ShowInfoConfirmAlertCommand(
            content: this.GetSystem<II18NSystem>().GetText("Quit the game?"),
            success: () => {
                this.SendEvent<ExitGameSceneEvent>();
                this.GetSystem<IPlayerManagerSystem>().peers.Clear();
                Time.timeScale = 1;
                this.SendCommand(new LoadSceneCommand(SceneID.Index));
            },
            fail: () => {
                Time.timeScale = 1;
            }));
    }
}
