using BaseLib.Pubsub;
using I7565H1Lib.Data.DTO;
using I7565H1Lib.Defines;
using SQLManager.Defines;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VCI_CAN_DotNET;
using BaseLib.Helper;
using System.Runtime.InteropServices;

namespace I7565H1Lib.Core
{

	//public class VCI_SDK_FOR_RELAY_ex
	//{
	//	#region dllname

	//	private const string DLLNAME = "VCI_CAN_FOR_RELAY.dll";

	//	#endregion

	//	#region method

	//	[DllImport(DLLNAME)]
	//	public static extern int VCI_CloseCAN(byte DevPort);

	//	[DllImport(DLLNAME)]
	//	public static extern int VCI_Clr_BufOverflowLED(byte CAN_No);

	//	[DllImport(DLLNAME)]
	//	public static extern int VCI_Clr_RxMsgBuf(byte CAN_No);

	//	[DllImport(DLLNAME)]
	//	public static extern int VCI_Clr_UserDefISR(byte ISRNo);

	//	[DllImport(DLLNAME)]
	//	public static extern int VCI_DisableHWCyclicTxMsg();

	//	[DllImport(DLLNAME)]
	//	public static extern int VCI_DisableHWCyclicTxMsgNo(byte HW_TimerNo);

	//	[DllImport(DLLNAME)]
	//	public static extern void VCI_DoEvents();

	//	[DllImport(DLLNAME)]
	//	public static extern int VCI_EnableHWCyclicTxMsgNo(byte CAN_No, byte Mode, byte RTR, byte DLC, uint ID, byte[] Data, uint TimePeriod, uint TransmitTimes, byte HW_TimerNo);

	//	[DllImport(DLLNAME)]
	//	public static extern int VCI_EnableHWCyclicTxMsgNo_Ex(byte CAN_No, byte Mode, byte RTR, byte DLC, uint ID, byte[] Data, uint TimePeriod, uint TransmitTimes, byte HW_TimerNo, byte AddMode, uint DLAddVal, uint DHAddVal);

	//	[DllImport(DLLNAME)]
	//	public static extern int VCI_EnableHWCyclicTxMsg_NoStruct(byte CAN_No, byte Mode, byte RTR, byte DLC, uint ID, byte[] Data, uint TimePeriod, uint TransmitTimes);

	//	[DllImport(DLLNAME)]
	//	public static extern int VCI_Get_CANBaud_BitTime(byte CAN_No, ref byte T1Val, ref byte T2Val, ref byte SJWVal);

	//	[DllImport(DLLNAME)]
	//	public static extern int VCI_Get_CANFID_NoStruct(byte CAN_No, ref ushort SSFF_Num, ref ushort GSFF_Num, ref ushort SEFF_Num, ref ushort GEFF_Num, ushort[] SSFF_FID, uint[] GSFF_FID, uint[] SEFF_FID, uint[] GEFF_FID);

	//	[DllImport(DLLNAME)]
	//	public static extern int VCI_Get_CANStatus_NoStruct(byte CAN_No, ref uint CurCANBaud, ref byte CANReg, ref byte CANTxErrCnt, ref byte CANRxErrCnt, ref byte MODState);

	//	[DllImport(DLLNAME)]
	//	public static extern ulong VCI_Get_DllVer();

	//	[DllImport(DLLNAME)]
	//	public static extern int VCI_Get_ISRCANData(byte ISRNo, ref byte DLC, byte[] Data);

	//	[DllImport(DLLNAME)]
	//	public static extern int VCI_Get_ISRCANData_Ex(byte ISRNo, ref uint ID, ref byte DLC, byte[] Data);

	//	[DllImport(DLLNAME)]
	//	public static extern int VCI_Get_MODInfo_NoStruct(char[] Mod_ID, char[] FW_Ver, char[] HW_SN);

	//	[DllImport(DLLNAME)]
	//	public static extern int VCI_Get_RxMsgBufIsFull(byte CAN_No, ref byte Flag);

	//	[DllImport(DLLNAME)]
	//	public static extern int VCI_Get_RxMsgCnt(byte CAN_No, ref uint RxMsgCnt);

	//	[DllImport(DLLNAME)]
	//	public static extern int VCI_OpenCAN_NoStruct(byte DevPort, byte DevType, uint CAN1_Baud, uint CAN2_Baud);

	//	[DllImport(DLLNAME)]
	//	public static extern int VCI_OpenCAN_NoStruct_Ex(byte DevPort, byte DevType, uint CAN1_Baud, uint CAN2_Baud, byte CAN1_T2Val, byte CAN2_T2Val);

	//	[DllImport(DLLNAME)]
	//	public static extern int VCI_RecvCANMsg_NoStruct(byte CAN_No, ref byte Mode, ref byte RTR, ref byte DLC, ref uint ID, ref uint TimeL, ref uint TimeH, byte[] Data);

	//	[DllImport(DLLNAME)]
	//	public static extern int VCI_Rst_MOD();

	//	[DllImport(DLLNAME)]
	//	public static extern int VCI_SendCANMsg_NoStruct(byte CAN_No, byte Mode, byte RTR, byte DLC, uint ID, byte[] Data);

	//	[DllImport(DLLNAME)]
	//	public static extern int VCI_Set_CANFID_AllPass(byte CAN_No);

	//	[DllImport(DLLNAME)]
	//	public static extern int VCI_Set_CANFID_NoStruct(byte CAN_No, ushort SSFF_Num, ushort GSFF_Num, ushort SEFF_Num, ushort GEFF_Num, ushort[] SSFF_FID, uint[] GSFF_FID, uint[] SEFF_FID, uint[] GEFF_FID);

	//	[DllImport(DLLNAME)]
	//	public static extern int VCI_Set_MOD_Ex(byte[] Data);

	//	[DllImport(DLLNAME)]
	//	public static extern int VCI_Set_UserDefISR(byte ISRNo, byte CAN_No, byte Mode, uint CANID, PFN_UserDefISR UserDefISR);

	//	public delegate void PFN_UserDefISR();

	//	#endregion

	//	#region variables

	//	public const int No_Err = 0;
	//	public const int DLC_7 = 7;
	//	public const int DLC_8 = 8;
	//	public const int ADDITION_MODE = 1;
	//	public const int MULTIPLE_MODE = 2;
	//	public const int ISRNO_0 = 0;
	//	public const int ISRNO_1 = 1;
	//	public const int ISRNO_2 = 2;
	//	public const int ISRNO_3 = 3;
	//	public const int ISRNO_4 = 4;
	//	public const int ISRNO_5 = 5;
	//	public const int ISRNO_6 = 6;
	//	public const int ISRNO_7 = 7;
	//	public const int ISR_CANMODE_ALL = 2;
	//	public const int ISR_CANID_ALL = 0;
	//	public const int CANBaud_5K = 5000;
	//	public const int CANBaud_10K = 10000;
	//	public const int CANBaud_20K = 20000;
	//	public const int CANBaud_40K = 40000;
	//	public const int CANBaud_50K = 50000;
	//	public const int CANBaud_80K = 80000;
	//	public const int CANBaud_100K = 100000;
	//	public const int CANBaud_125K = 125000;
	//	public const int CANBaud_200K = 200000;
	//	public const int CANBaud_250K = 250000;
	//	public const int CANBaud_400K = 400000;
	//	public const int CANBaud_500K = 500000;
	//	public const int CANBaud_600K = 600000;
	//	public const int CANBaud_800K = 800000;
	//	public const int CANBaud_1000K = 1000000;
	//	public const int DLC_6 = 6;
	//	public const int DLC_5 = 5;
	//	public const int ISR_CANPORT_ALL = 0;
	//	public const int DLC_3 = 3;
	//	public const int DEV_ModName_Err = 1;
	//	public const int DLC_4 = 4;
	//	public const int DEV_PortNotExist_Err = 3;
	//	public const int DEV_PortInUse_Err = 4;
	//	public const int DEV_PortNotOpen_Err = 5;
	//	public const int CAN_ConfigFail_Err = 6;
	//	public const int CAN_HARDWARE_Err = 7;
	//	public const int CAN_PortNo_Err = 8;
	//	public const int CAN_FIDLength_Err = 9;
	//	public const int CAN_DevDisconnect_Err = 10;
	//	public const int CAN_TimeOut_Err = 11;
	//	public const int CAN_ConfigCmd_Err = 12;
	//	public const int CAN_ConfigBusy_Err = 13;
	//	public const int CAN_RxBufEmpty = 14;
	//	public const int CAN_TxBufFull = 15;
	//	public const int DEV_ModNotExist_Err = 2;
	//	public const int CAN_HWSendTimerNo_Err = 17;
	//	public const int DLC_2 = 2;
	//	public const int DLC_1 = 1;
	//	public const int DLC_0 = 0;
	//	public const int RTR_1 = 1;
	//	public const int CAN_UserDefISRNo_Err = 16;
	//	public const int MODE_29BIT = 1;
	//	public const int MODE_11BIT = 0;
	//	public const int RTR_0 = 0;
	//	public const int I7565H1 = 1;
	//	public const int COMM_MODE = 1;
	//	public const int CONFIG_MODE = 0;
	//	public const int CAN2 = 2;
	//	public const int CAN1 = 1;
	//	public const int I7565H2 = 2;

	//	#endregion
	//}

	public abstract class AI7565H1 : BaseLib.Pubsub.ASubscribableBase<string>
	{
		#region constructor

		public AI7565H1(Type sdk, LogDev logDev, int channelNo) : base(logDev, channelNo)
		{
			SDK = Activator.CreateInstance(sdk);

			VCI_Set_MOD_Ex = GetMethod("VCI_Set_MOD_Ex");
			VCI_OpenCAN_NoStruct = GetMethod("VCI_OpenCAN_NoStruct");
			VCI_CloseCAN = GetMethod("VCI_CloseCAN");
			VCI_Get_CANStatus_NoStruct = GetMethod("VCI_Get_CANStatus_NoStruct");
			VCI_Get_MODInfo_NoStruct = GetMethod("VCI_Get_MODInfo_NoStruct");
			VCI_Clr_BufOverflowLED = GetMethod("VCI_Clr_BufOverflowLED");
			VCI_DoEvents = GetMethod("VCI_DoEvents");
			VCI_Rst_MOD = GetMethod("VCI_Rst_MOD");
			VCI_SendCANMsg_NoStruct = GetMethod("VCI_SendCANMsg_NoStruct");
			VCI_Get_RxMsgCnt = GetMethod("VCI_Get_RxMsgCnt");
			VCI_RecvCANMsg_NoStruct = GetMethod("VCI_RecvCANMsg_NoStruct");
		}

		#endregion

		#region property

		private object SDK { get; set; }

		private byte DevPort { get; set; }

		private System.Reflection.MethodInfo VCI_Set_MOD_Ex { get; set; }
		private System.Reflection.MethodInfo VCI_OpenCAN_NoStruct { get; set; }
		private System.Reflection.MethodInfo VCI_CloseCAN { get; set; }
		private System.Reflection.MethodInfo VCI_Get_CANStatus_NoStruct { get; set; }
		private System.Reflection.MethodInfo VCI_Get_MODInfo_NoStruct { get; set; }
		private System.Reflection.MethodInfo VCI_Clr_BufOverflowLED { get; set; }
		private System.Reflection.MethodInfo VCI_DoEvents { get; set; }
		private System.Reflection.MethodInfo VCI_Rst_MOD { get; set; }
		private System.Reflection.MethodInfo VCI_SendCANMsg_NoStruct { get; set; }
		private System.Reflection.MethodInfo VCI_Get_RxMsgCnt { get; set; }
		private System.Reflection.MethodInfo VCI_RecvCANMsg_NoStruct { get; set; }

		#endregion

		#region method

		private System.Reflection.MethodInfo GetMethod(string name)
		{
			return SDK.GetType().GetMethod(name);
		}

		protected bool OpenCAN(string portName, uint baud)
		{
			try
			{
				byte devPort = Convert.ToByte(portName.Replace("COM", ""));

				ConnectionState = BaseLib.Defines.ConnectionStates.Connecting;
				Publish(PushDataDTO.PushDataTypes.Open, $"opening CAN", -1);
				WriteLog($"[{LogDevice}] opening CAN : {portName}");

				byte[] Mod_CfgData = new byte[512];

				//Listen Only Mode
				Mod_CfgData[0] = 0;                     //CAN1 => 0:Disable, 1:Enable
				Mod_CfgData[1] = 0;                     //CAN2 => 0:Disable, 1:Enable
#if true
				VCI_Set_MOD_Ex.Invoke(SDK, new object[] { Mod_CfgData });
#else
				//VCI_Set_MOD_Ex.set =(Mod_CfgData);
				VCI_SDK_FOR_RELAY_ex vciEx =	new VCI_SDK_FOR_RELAY_ex();

				vciEx.VCI_Set_MOD_Ex( Mod_CfgData );
#endif

				DevPort = devPort;
				int Ret = (int)VCI_OpenCAN_NoStruct.Invoke(SDK, new object[] { devPort, (byte)DevTypes.I_7565_H1, baud, baud });
				if (Ret != 0)
				{
					ConnectionState = BaseLib.Defines.ConnectionStates.Disconnected;
					Publish(PushDataDTO.PushDataTypes.Open, $"OpenCAN failure {Constants.GetErrorMessage(Ret)}", -1, LogLevels.E);
					WriteLog($"[{LogDevice}] OpenCAN failure {Constants.GetErrorMessage(Ret)}");

					return false;
				}
				else
				{
					ConnectionState = BaseLib.Defines.ConnectionStates.Connected;
					Publish(PushDataDTO.PushDataTypes.Open, $"OpenCAN Success", -1);
					WriteLog($"[{LogDevice}] OpenCAN Success");

					return true;
				}
			}
			catch (Exception ex)
			{
				ConnectionState = BaseLib.Defines.ConnectionStates.Disconnected;
				Console.Out.WriteLine(ex.ToString());
			//	BaseLib.Helper.LogHelper.log.Debug(e.Message);
			//	BaseLib.Helper.LogHelper.log.Debug(e.ToString());// "Main() started");

				return false;
			}
		}

		public  void CloseCAN()
		{
			WriteLog($"[{LogDevice}] CloseCAN : {DevPort}");
			ConnectionState = BaseLib.Defines.ConnectionStates.Disconnected;

			int ret = (int)VCI_CloseCAN.Invoke(SDK, new object[] { DevPort });
			if (ret != 0)
			{
				Publish(PushDataDTO.PushDataTypes.Close, $"CloseCAN failure {Constants.GetErrorMessage(ret)}", -1, LogLevels.E);
				WriteLog($"[{LogDevice}] CloseCAN failure {Constants.GetErrorMessage(ret)}");
			}
			else
			{
				Publish(PushDataDTO.PushDataTypes.Close, "CloseCAN Success", -1);
				WriteLog($"[{LogDevice}] CloseCAN Success");
			}
		}

		public CANStatusDTO GetCANStatus(byte canNo)
		{
			var dto = new CANStatusDTO();

			object[] arguments = new object[] { canNo, null, null, null, null, null };
			int ret = (int)VCI_Get_CANStatus_NoStruct.Invoke(SDK, arguments);
			uint CurCANBaud = (uint)arguments[1];
			byte CANReg = (byte)arguments[2];
			byte CANTxErrCnt = (byte)arguments[3];
			byte CANRxErrCnt = (byte)arguments[4];
			byte ModState = (byte)arguments[5];

			if (ret != 0)
			{
				Publish(PushDataDTO.PushDataTypes.Log, $"GetCANStatus {Constants.GetErrorMessage(ret)}", -1, LogLevels.E);
				WriteLog($"GetCANStatus {Constants.GetErrorMessage(ret)}");
			}
			else
			{
				dto = new CANStatusDTO
				{
					CANNo = canNo,
					CurCANBaud = CurCANBaud,
					CANReg = CANReg,
					CANTxErrCnt = CANTxErrCnt,
					CANRxErrCnt = CANRxErrCnt,
					ModState = ModState
				};

				Publish(PushDataDTO.PushDataTypes.Data, dto, -1);

				WriteLog($"[CAN{canNo}_Status] " +
					$"Baudrate: {string.Format("{0:0000.000}", CurCANBaud / 1000)} (Kbps), " +
					$"Register: {string.Format("0x{0:X2}", CANReg)}, " +
					$"TxErrCnt: {string.Format("0x{0:X2}", CANTxErrCnt)}, " +
					$"RxErrCnt: {string.Format("0x{0:X2}", CANRxErrCnt)}, " +
					$"ModState: {string.Format("0x{0:X2}", ModState)}"
				);
			} // end if

			return dto;
		}

		public ModInfoDTO GetModInfo()
		{
			var dto = new ModInfoDTO();

			char[] ModID = new char[12];
			char[] FWVer = new char[12];
			char[] HWSN = new char[16];

			int ret = (int)VCI_Get_MODInfo_NoStruct.Invoke(SDK, new object[] { ModID, FWVer, HWSN });
			if (ret != 0)
			{
				Publish(PushDataDTO.PushDataTypes.Log, $"GetModInfo {Constants.GetErrorMessage(ret)}", -1, LogLevels.E);
				WriteLog($"GetModInfo {Constants.GetErrorMessage(ret)}");
			}
			else
			{
				dto = new ModInfoDTO(new string(ModID).Trim('\0'), new string(FWVer).Trim('\0'), new string(HWSN).Trim('\0'));

				Publish(PushDataDTO.PushDataTypes.Data, dto, -1);

				WriteLog($"ModName= {dto.ModID}, FW_Ver= {dto.FWVer}, HW_SN= {dto.HWSN}");
			}

			return dto;
		}

		public void ClearErrorLED(byte canNo)
		{
			int ret = (int)VCI_Clr_BufOverflowLED.Invoke(SDK, new object[] { canNo });
			if (ret != 0)
			{
				Console.Out.WriteLine(Constants.GetErrorMessage(ret));
			}
			else
			{
				Console.Out.WriteLine($"Clear CAN{canNo} ErrLED OK");
			}
		}

		public void ResetModule()
		{
			Console.Out.WriteLine("Waiting for Reset Module OK ...");

			VCI_DoEvents.Invoke(SDK, new object[] { });
			int ret = (int)VCI_Rst_MOD.Invoke(SDK, new object[] { });
			if (ret == 10)
			{
				Console.Out.WriteLine("Module Reset OK");
			}
			else
			{
				Console.Out.WriteLine(Constants.GetErrorMessage(ret));
			}

			CloseCAN();
		}

		protected void SendCANMsg(byte CANNo, byte mode, byte rtr, byte dlc, uint CANId, byte[] data)
		{
			int ret = (int)VCI_SendCANMsg_NoStruct.Invoke(SDK, new object[] { CANNo, mode, rtr, dlc, CANId, data });
			if (ret != 0)
			{
				Console.Out.WriteLine(Constants.GetErrorMessage(ret));
			}
			else
			{
				Console.Out.WriteLine($"Send CAN {CANNo} Msg OK");

			}
		}

		public uint GetRXMsgCnt(byte canNo)
		{
			object[] arguments = new object[] { canNo, null };
			int ret = (int)VCI_Get_RxMsgCnt.Invoke(SDK, arguments);
			uint RxMsgCnt = (uint)arguments[1];

			if (ret != 0)
			{
				Console.Out.WriteLine(Constants.GetErrorMessage(ret));
			}
			else
			{
				//Console.Out.WriteLine($"CAN{CANNo} RxMsgCnt : {RxMsgCnt}");
			}

			return RxMsgCnt;
		}

		protected byte[] RecvCANMsg(byte CANNo, ref byte mode, ref byte rtr, ref byte dlc, ref uint canId, ref uint timeL, ref uint timeH)
		{
			byte[] data = new byte[8];

			object[] arguments = new object[] { CANNo, null, null, null, null, null, null, data };
			int ret = (int)VCI_RecvCANMsg_NoStruct.Invoke(SDK, arguments);
			mode = (byte)arguments[1];
			rtr = (byte)arguments[2];
			dlc = (byte)arguments[3];
			canId = (uint)arguments[4];
			timeL = (uint)arguments[5];
			timeH = (uint)arguments[6];

			if (ret != 0)
			{
				Console.Out.WriteLine(Constants.GetErrorMessage(ret));
				return null;
			}
			else
			{
				return data;
			}
		}

#endregion

	}
}
