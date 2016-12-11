using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class InputModuleScript : MonoBehaviour{


	public GameObject m_TargetObject;
	private string m_HorizontalAxis = "Horizontal";
	private string m_VerticalAxis = "Vertical";
	private string m_SubmitButton = "Submit";
	private string m_CancelButton = "Cancel";
	private float m_inputActionsPerSecond = 10;

	public float inputActionsPerSecond{
		get { return m_inputActionsPerSecond; }
		set { m_inputActionsPerSecond = value; }
	}
	public string horizontalAxis{
		get { return m_HorizontalAxis; }
		set { m_HorizontalAxis = value; }
	}
	public string verticalAxis{
		get { return m_VerticalAxis; }
		set { m_VerticalAxis = value; }
	}
	public string submitButton{
		get { return m_SubmitButton; }
		set { m_SubmitButton = value; }
	}
	public string cancelButton{
		get { return m_CancelButton; }
		set { m_CancelButton = value; }
	}

	/*
	public override void Process(){
		if (m_TargetObject == null) {
			return;
		}
		bool usedEvent = SendUpdateEventToSelectedObject ();
		if (eventSystem.sendNavigationEvents) {
			if (!usedEvent) {
				usedEvent |= SendMoveEventToSelectedObject ();
			}
			if (!usedEvent) {
				SendSubmitEventToSelectedObject ();
			}
		}
		ExecuteEvents.Execute (m_TargetObject, new BaseEventData (eventSystem), ExecuteEvents.moveHandler);
	}

	private bool SendMoveEventToSelectedObject(){
		float time = Time.unscaledTime;

		Vector2 movement = GetRawMoveVector ();

		var axisEventData = GetAxisEventData (movement.x, movement.y, 0.6f);
		
	
	}
	*/
}
