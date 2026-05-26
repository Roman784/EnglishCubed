#include "pch-cpp.hpp"





template <typename T1, typename T2>
struct VirtualActionInvoker2
{
	typedef void (*Action)(void*, T1, T2, const RuntimeMethod*);

	static inline void Invoke (Il2CppMethodSlot slot, RuntimeObject* obj, T1 p1, T2 p2)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_virtual_invoke_data(slot, obj);
		((Action)invokeData.methodPtr)(obj, p1, p2, invokeData.method);
	}
};
template <typename R, typename T1>
struct VirtualFuncInvoker1
{
	typedef R (*Func)(void*, T1, const RuntimeMethod*);

	static inline R Invoke (Il2CppMethodSlot slot, RuntimeObject* obj, T1 p1)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_virtual_invoke_data(slot, obj);
		return ((Func)invokeData.methodPtr)(obj, p1, invokeData.method);
	}
};

struct Action_1_t4886BB533893363037886031AFA3134F2BE506A0;
struct Action_1_t6F9EB113EB3F16226AEF811A2744F4111C116C87;
struct ArrayPool_1_tA078350A0D495C7FFCFF5BF612FA605A894B24F7;
struct Func_1_t8C8AB5C3244441F8D3FD536FF3DC2BB60FD22F87;
struct Func_1_tD5C081AE11746B200C711DD48DBEB00E3A9276D4;
struct Lazy_1_tFDCCF60E5E7B218CA86C19EE6C5DDE4FEC239292;
struct Lazy_1_tAD66CD7CC97BB996411F4FE0F49A1817031B906E;
struct BooleanU5BU5D_tD317D27C31DB892BE79FAE3AEBC0B3FFB73DE9B4;
struct ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031;
struct CharU5BU5D_t799905CF001DD5F13F7DBB310181FC4D8B7D0AAB;
struct DelegateU5BU5D_tC5AB7E8F745616680F337909D3A8E6C722CDF771;
struct IntPtrU5BU5D_tFD177F8C806A6921AD7150264CCC62FA00CAD832;
struct ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918;
struct StackTraceU5BU5D_t32FBCB20930EAF5BAE3F450FF75228E5450DA0DF;
struct StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248;
struct TypeU5BU5D_t97234E1129B564EB38B8D85CAC2AD8B5B9522FFB;
struct Attribute_tFDA8EFEFB0711976D22474794576DAF28F7440AA;
struct Binder_t91BFCE95A7057FADF4D8A1A342AFE52872246235;
struct CallerArgumentExpressionAttribute_tB1FD8CA0D06B5ACEC737C828D31B36A25C48F93F;
struct CollectionBuilderAttribute_t0D128F8E3C653D54D529BEF107D59E2465C3F390;
struct CollectionEventDispatcherEventArgs_t897929345863379302C0A2FDAF37F55BA7247339;
struct CompilerFeatureRequiredAttribute_t5830197792FF240CE22E91AE211F4F87F79A1C91;
struct DelegateData_t9B286B493293CD2D23A5B2B5EF0E5B1324C2B77E;
struct EmbeddedAttribute_tB3AA6A121F64C34903793F66EFADF13D69D84243;
struct ExperimentalAttribute_t1DBB6B99498094652CE6971BD0C49000A306AB40;
struct ICollectionEventDispatcher_t5D9511C5E9D3DAEB9C1B98D729ACBE020C000A7D;
struct IDictionary_t6D03155AF1FA9083817AA5B6AD7DEEACC26AB220;
struct IList_t1C522956D79B7DC92B5B01053DF1AC058C8B598D;
struct InlineCollectionEventDispatcher_t6C5003C831CE0A044CB873B6A3058B992900D761;
struct InterpolatedStringHandlerArgumentAttribute_tED51A430CF519FA32AB6A2750702B2A9E53AB750;
struct InterpolatedStringHandlerAttribute_tD2D4F0E2ED6A3231C5DB88178D29F00B5902C74E;
struct InvalidOperationException_t5DDE4D49B7405FAAB1E4576F4715A42A3FAD4BAB;
struct LazyHelper_t1784351780B2D1AC002869BB3C7A35AA64762602;
struct MemberFilter_tF644F1AE82F611B677CE1964D5A3277DDA21D553;
struct MemberNotNullAttribute_tA7E83A64A957FC6B520A7C96CCECE5DC95274913;
struct MemberNotNullWhenAttribute_tD97AA77F62B1B44576483DFF7E3419171D10ED23;
struct MethodInfo_t;
struct ModuleInitializerAttribute_t2FF4CF8CAA5DDB62A007C08EF5E2AEF1B479F3D7;
struct NotifyCollectionChangedEventArgs_tFF32515F3E2B116CAB376B5B57C6A8CB617351FA;
struct NullableAttribute_t9A0E8C2E8A6F4BEC0A70CC54F3279B3E415C4914;
struct NullableContextAttribute_tEB43CD155472303BE2B5557D07B65ED056B0BD16;
struct RefSafetyRulesAttribute_t5898C461874BCE9DD3DC7B3A2499589F869A7051;
struct RequiredMemberAttribute_t54CFC673EC99CC20400099B7A91C5D224FF6890B;
struct RequiresLocationAttribute_tF98B5396649241CB497A05F191708BA819095FF3;
struct RequiresPreviewFeaturesAttribute_tAE740C3CCA0F8D10D5F5AA35EA55111023DFADB2;
struct SafeSerializationManager_tCBB85B95DFD1634237140CD892E82D06ECB3F5E6;
struct SendOrPostCallback_t5C292A12062F24027A98492F52ECFE9802AA6F0E;
struct SetsRequiredMembersAttribute_t6DA5C73E07B0708646CA8B49A79E43DC6D7760B6;
struct SkipLocalsInitAttribute_t8CFB142CB8317D704982FCF1DAD151079BF1F4F9;
struct String_t;
struct StringSyntaxAttribute_t5016B3EF90D82CE59E1CD3CD6AF9F4053A3CFE68;
struct SynchronizationContext_tCDB842BBE53B050802CBBB59C6E6DC45B5B06DC0;
struct SynchronizationContextCollectionEventDispatcher_tD0A54D5AF16049B806210282D1017E5DFF3108A9;
struct Type_t;
struct UnscopedRefAttribute_tA2C91E96C25BDF07D6891F9FA9990C8E4CE5B38B;
struct Void_t4861ACF8F4594C3437BB48B6E56783494B843915;
struct U3CU3Ec_tD3BCC22757396379C0AF60029CE9F7011891CDB7;

IL2CPP_EXTERN_C RuntimeClass* ArrayPool_1_tA078350A0D495C7FFCFF5BF612FA605A894B24F7_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* BooleanU5BU5D_tD317D27C31DB892BE79FAE3AEBC0B3FFB73DE9B4_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* CollectionEventDispatcherEventArgs_t897929345863379302C0A2FDAF37F55BA7247339_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Func_1_t8C8AB5C3244441F8D3FD536FF3DC2BB60FD22F87_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* InlineCollectionEventDispatcher_t6C5003C831CE0A044CB873B6A3058B992900D761_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* InvalidOperationException_t5DDE4D49B7405FAAB1E4576F4715A42A3FAD4BAB_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Lazy_1_tFDCCF60E5E7B218CA86C19EE6C5DDE4FEC239292_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* SendOrPostCallback_t5C292A12062F24027A98492F52ECFE9802AA6F0E_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* SynchronizationContextCollectionEventDispatcher_tD0A54D5AF16049B806210282D1017E5DFF3108A9_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* U3CU3Ec_tD3BCC22757396379C0AF60029CE9F7011891CDB7_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C String_t* _stringLiteral02FF37CC36577E5BBF8EE3F26D829C00193B4DB8;
IL2CPP_EXTERN_C const RuntimeMethod* ArrayPool_1_get_Shared_m4880204C02055CC88D825651B2940134A9F99C35_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* Lazy_1__ctor_m6302B6ABC895FA85915F9773675C29AD11C7243C_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* Lazy_1_get_Value_mF4F983F782F878359F3120BA280C70276FED6536_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* MemoryExtensions_AsSpan_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_m4B450C631366925983E48616CE396F35E694835D_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* Span_1_get_Length_mED1253429B93CB6D2928015A22105A16FF64C86B_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* SynchronizationContextCollectionEventDispatcher_SendOrPostCallback_mD6486EAD82C0B2C3CE78E168A6436A9322C95009_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* U3CU3Ec_U3C_cctorU3Eb__7_0_m4068156446C496AA1FF7C88C0705168262FAA44F_RuntimeMethod_var;
struct Delegate_t_marshaled_com;
struct Delegate_t_marshaled_pinvoke;
struct Exception_t_marshaled_com;
struct Exception_t_marshaled_pinvoke;

struct BooleanU5BU5D_tD317D27C31DB892BE79FAE3AEBC0B3FFB73DE9B4;
struct ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031;
struct ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918;
struct StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248;

IL2CPP_EXTERN_C_BEGIN
IL2CPP_EXTERN_C_END

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
struct U3CModuleU3E_t0ED68106E9C915753225F1BFC927D9F8151BB759 
{
};
struct ArrayPool_1_tA078350A0D495C7FFCFF5BF612FA605A894B24F7  : public RuntimeObject
{
};
struct Lazy_1_tFDCCF60E5E7B218CA86C19EE6C5DDE4FEC239292  : public RuntimeObject
{
	LazyHelper_t1784351780B2D1AC002869BB3C7A35AA64762602* ____state;
	Func_1_t8C8AB5C3244441F8D3FD536FF3DC2BB60FD22F87* ____factory;
	RuntimeObject* ____value;
};
struct Attribute_tFDA8EFEFB0711976D22474794576DAF28F7440AA  : public RuntimeObject
{
};
struct CollectionExtensions_tFA4608AECDCC75C8DC4A7822355030677BFB5AF2  : public RuntimeObject
{
};
struct CollectionsMarshal_t750E4E96A1456A3396B3A161B9CC444946867744  : public RuntimeObject
{
};
struct EventArgs_t37273F03EAC87217701DD431B190FBD84AD7C377  : public RuntimeObject
{
};
struct InlineCollectionEventDispatcher_t6C5003C831CE0A044CB873B6A3058B992900D761  : public RuntimeObject
{
};
struct IsExternalInit_t478B5F1A8089D35F9DEB889AD7E3F46F82D73F69  : public RuntimeObject
{
};
struct MemberInfo_t  : public RuntimeObject
{
};
struct ObservableCollectionExtensions_t7C752613186C073258BCA65108AE921C3EF65D9B  : public RuntimeObject
{
};
struct RuntimeHelpersEx_tE9A8BB10DA76044CA4AD76440C6E9E15C734B826  : public RuntimeObject
{
};
struct String_t  : public RuntimeObject
{
	int32_t ____stringLength;
	Il2CppChar ____firstChar;
};
struct SynchronizationContextCollectionEventDispatcher_tD0A54D5AF16049B806210282D1017E5DFF3108A9  : public RuntimeObject
{
	SynchronizationContext_tCDB842BBE53B050802CBBB59C6E6DC45B5B06DC0* ___synchronizationContext;
};
struct SynchronizedViewExtensions_t8C74BEA747BC934A3ABFB0DE9B0FE52B1EFA15B1  : public RuntimeObject
{
};
struct ValueType_t6D9B272BD21782F0A9A14F2E41F85A50E97A986F  : public RuntimeObject
{
};
struct ValueType_t6D9B272BD21782F0A9A14F2E41F85A50E97A986F_marshaled_pinvoke
{
};
struct ValueType_t6D9B272BD21782F0A9A14F2E41F85A50E97A986F_marshaled_com
{
};
struct U3CU3Ec_tD3BCC22757396379C0AF60029CE9F7011891CDB7  : public RuntimeObject
{
};
struct Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22 
{
	bool ___m_value;
};
struct Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3 
{
	uint8_t ___m_value;
};
struct CallerArgumentExpressionAttribute_tB1FD8CA0D06B5ACEC737C828D31B36A25C48F93F  : public Attribute_tFDA8EFEFB0711976D22474794576DAF28F7440AA
{
	String_t* ___U3CParameterNameU3Ek__BackingField;
};
struct CollectionBuilderAttribute_t0D128F8E3C653D54D529BEF107D59E2465C3F390  : public Attribute_tFDA8EFEFB0711976D22474794576DAF28F7440AA
{
	Type_t* ___U3CBuilderTypeU3Ek__BackingField;
	String_t* ___U3CMethodNameU3Ek__BackingField;
};
struct CompilerFeatureRequiredAttribute_t5830197792FF240CE22E91AE211F4F87F79A1C91  : public Attribute_tFDA8EFEFB0711976D22474794576DAF28F7440AA
{
	String_t* ___U3CFeatureNameU3Ek__BackingField;
	bool ___U3CIsOptionalU3Ek__BackingField;
};
struct EmbeddedAttribute_tB3AA6A121F64C34903793F66EFADF13D69D84243  : public Attribute_tFDA8EFEFB0711976D22474794576DAF28F7440AA
{
};
struct Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2  : public ValueType_t6D9B272BD21782F0A9A14F2E41F85A50E97A986F
{
};
struct Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_marshaled_pinvoke
{
};
struct Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_marshaled_com
{
};
struct ExperimentalAttribute_t1DBB6B99498094652CE6971BD0C49000A306AB40  : public Attribute_tFDA8EFEFB0711976D22474794576DAF28F7440AA
{
	String_t* ___U3CDiagnosticIdU3Ek__BackingField;
	String_t* ___U3CUrlFormatU3Ek__BackingField;
};
struct Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C 
{
	int32_t ___m_value;
};
struct IntPtr_t 
{
	void* ___m_value;
};
struct InterpolatedStringHandlerArgumentAttribute_tED51A430CF519FA32AB6A2750702B2A9E53AB750  : public Attribute_tFDA8EFEFB0711976D22474794576DAF28F7440AA
{
	StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248* ___U3CArgumentsU3Ek__BackingField;
};
struct InterpolatedStringHandlerAttribute_tD2D4F0E2ED6A3231C5DB88178D29F00B5902C74E  : public Attribute_tFDA8EFEFB0711976D22474794576DAF28F7440AA
{
};
struct MemberNotNullAttribute_tA7E83A64A957FC6B520A7C96CCECE5DC95274913  : public Attribute_tFDA8EFEFB0711976D22474794576DAF28F7440AA
{
	StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248* ___U3CMembersU3Ek__BackingField;
};
struct MemberNotNullWhenAttribute_tD97AA77F62B1B44576483DFF7E3419171D10ED23  : public Attribute_tFDA8EFEFB0711976D22474794576DAF28F7440AA
{
	bool ___U3CReturnValueU3Ek__BackingField;
	StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248* ___U3CMembersU3Ek__BackingField;
};
struct ModuleInitializerAttribute_t2FF4CF8CAA5DDB62A007C08EF5E2AEF1B479F3D7  : public Attribute_tFDA8EFEFB0711976D22474794576DAF28F7440AA
{
};
struct NullableAttribute_t9A0E8C2E8A6F4BEC0A70CC54F3279B3E415C4914  : public Attribute_tFDA8EFEFB0711976D22474794576DAF28F7440AA
{
	ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___NullableFlags;
};
struct NullableContextAttribute_tEB43CD155472303BE2B5557D07B65ED056B0BD16  : public Attribute_tFDA8EFEFB0711976D22474794576DAF28F7440AA
{
	uint8_t ___Flag;
};
struct RefSafetyRulesAttribute_t5898C461874BCE9DD3DC7B3A2499589F869A7051  : public Attribute_tFDA8EFEFB0711976D22474794576DAF28F7440AA
{
	int32_t ___Version;
};
struct RequiredMemberAttribute_t54CFC673EC99CC20400099B7A91C5D224FF6890B  : public Attribute_tFDA8EFEFB0711976D22474794576DAF28F7440AA
{
};
struct RequiresLocationAttribute_tF98B5396649241CB497A05F191708BA819095FF3  : public Attribute_tFDA8EFEFB0711976D22474794576DAF28F7440AA
{
};
struct RequiresPreviewFeaturesAttribute_tAE740C3CCA0F8D10D5F5AA35EA55111023DFADB2  : public Attribute_tFDA8EFEFB0711976D22474794576DAF28F7440AA
{
	String_t* ___U3CMessageU3Ek__BackingField;
	String_t* ___U3CUrlU3Ek__BackingField;
};
struct SetsRequiredMembersAttribute_t6DA5C73E07B0708646CA8B49A79E43DC6D7760B6  : public Attribute_tFDA8EFEFB0711976D22474794576DAF28F7440AA
{
};
struct SkipLocalsInitAttribute_t8CFB142CB8317D704982FCF1DAD151079BF1F4F9  : public Attribute_tFDA8EFEFB0711976D22474794576DAF28F7440AA
{
};
struct StringSyntaxAttribute_t5016B3EF90D82CE59E1CD3CD6AF9F4053A3CFE68  : public Attribute_tFDA8EFEFB0711976D22474794576DAF28F7440AA
{
	String_t* ___U3CSyntaxU3Ek__BackingField;
	ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918* ___U3CArgumentsU3Ek__BackingField;
};
struct UnscopedRefAttribute_tA2C91E96C25BDF07D6891F9FA9990C8E4CE5B38B  : public Attribute_tFDA8EFEFB0711976D22474794576DAF28F7440AA
{
};
struct Void_t4861ACF8F4594C3437BB48B6E56783494B843915 
{
	union
	{
		struct
		{
		};
		uint8_t Void_t4861ACF8F4594C3437BB48B6E56783494B843915__padding[1];
	};
};
struct ByReference_1_t98C4399D749F9F8F828547057023CF78951E6126 
{
	intptr_t ____value;
};
struct Delegate_t  : public RuntimeObject
{
	intptr_t ___method_ptr;
	intptr_t ___invoke_impl;
	RuntimeObject* ___m_target;
	intptr_t ___method;
	intptr_t ___delegate_trampoline;
	intptr_t ___extra_arg;
	intptr_t ___method_code;
	intptr_t ___interp_method;
	intptr_t ___interp_invoke_impl;
	MethodInfo_t* ___method_info;
	MethodInfo_t* ___original_method_info;
	DelegateData_t9B286B493293CD2D23A5B2B5EF0E5B1324C2B77E* ___data;
	bool ___method_is_virtual;
};
struct Delegate_t_marshaled_pinvoke
{
	intptr_t ___method_ptr;
	intptr_t ___invoke_impl;
	Il2CppIUnknown* ___m_target;
	intptr_t ___method;
	intptr_t ___delegate_trampoline;
	intptr_t ___extra_arg;
	intptr_t ___method_code;
	intptr_t ___interp_method;
	intptr_t ___interp_invoke_impl;
	MethodInfo_t* ___method_info;
	MethodInfo_t* ___original_method_info;
	DelegateData_t9B286B493293CD2D23A5B2B5EF0E5B1324C2B77E* ___data;
	int32_t ___method_is_virtual;
};
struct Delegate_t_marshaled_com
{
	intptr_t ___method_ptr;
	intptr_t ___invoke_impl;
	Il2CppIUnknown* ___m_target;
	intptr_t ___method;
	intptr_t ___delegate_trampoline;
	intptr_t ___extra_arg;
	intptr_t ___method_code;
	intptr_t ___interp_method;
	intptr_t ___interp_invoke_impl;
	MethodInfo_t* ___method_info;
	MethodInfo_t* ___original_method_info;
	DelegateData_t9B286B493293CD2D23A5B2B5EF0E5B1324C2B77E* ___data;
	int32_t ___method_is_virtual;
};
struct Exception_t  : public RuntimeObject
{
	String_t* ____className;
	String_t* ____message;
	RuntimeObject* ____data;
	Exception_t* ____innerException;
	String_t* ____helpURL;
	RuntimeObject* ____stackTrace;
	String_t* ____stackTraceString;
	String_t* ____remoteStackTraceString;
	int32_t ____remoteStackIndex;
	RuntimeObject* ____dynamicMethods;
	int32_t ____HResult;
	String_t* ____source;
	SafeSerializationManager_tCBB85B95DFD1634237140CD892E82D06ECB3F5E6* ____safeSerializationManager;
	StackTraceU5BU5D_t32FBCB20930EAF5BAE3F450FF75228E5450DA0DF* ___captured_traces;
	IntPtrU5BU5D_tFD177F8C806A6921AD7150264CCC62FA00CAD832* ___native_trace_ips;
	int32_t ___caught_in_unmanaged;
};
struct Exception_t_marshaled_pinvoke
{
	char* ____className;
	char* ____message;
	RuntimeObject* ____data;
	Exception_t_marshaled_pinvoke* ____innerException;
	char* ____helpURL;
	Il2CppIUnknown* ____stackTrace;
	char* ____stackTraceString;
	char* ____remoteStackTraceString;
	int32_t ____remoteStackIndex;
	Il2CppIUnknown* ____dynamicMethods;
	int32_t ____HResult;
	char* ____source;
	SafeSerializationManager_tCBB85B95DFD1634237140CD892E82D06ECB3F5E6* ____safeSerializationManager;
	StackTraceU5BU5D_t32FBCB20930EAF5BAE3F450FF75228E5450DA0DF* ___captured_traces;
	Il2CppSafeArray* ___native_trace_ips;
	int32_t ___caught_in_unmanaged;
};
struct Exception_t_marshaled_com
{
	Il2CppChar* ____className;
	Il2CppChar* ____message;
	RuntimeObject* ____data;
	Exception_t_marshaled_com* ____innerException;
	Il2CppChar* ____helpURL;
	Il2CppIUnknown* ____stackTrace;
	Il2CppChar* ____stackTraceString;
	Il2CppChar* ____remoteStackTraceString;
	int32_t ____remoteStackIndex;
	Il2CppIUnknown* ____dynamicMethods;
	int32_t ____HResult;
	Il2CppChar* ____source;
	SafeSerializationManager_tCBB85B95DFD1634237140CD892E82D06ECB3F5E6* ____safeSerializationManager;
	StackTraceU5BU5D_t32FBCB20930EAF5BAE3F450FF75228E5450DA0DF* ___captured_traces;
	Il2CppSafeArray* ___native_trace_ips;
	int32_t ___caught_in_unmanaged;
};
struct NotifyCollectionChangedAction_tA580EA64F38D1FB2B1470FDD8266E5F32666D9FF 
{
	int32_t ___value__;
};
struct RejectedViewChangedAction_t0BFCF5DA33A23EE1BD487A7BD67D02F41BAA4C7F 
{
	int32_t ___value__;
};
struct RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B 
{
	intptr_t ___value;
};
struct SynchronizationContextProperties_t5ED82C778B4C396AD94A93CFBEF00022BDECF058 
{
	int32_t ___value__;
};
struct RawData_t37CAF2D3F74B7723974ED7CEEE9B297D8FA64ED0  : public RuntimeObject
{
	intptr_t ___Bounds;
	intptr_t ___Count;
	uint8_t ___Data;
};
struct RawData_t37CAF2D3F74B7723974ED7CEEE9B297D8FA64ED0_marshaled_pinvoke
{
	intptr_t ___Bounds;
	intptr_t ___Count;
	uint8_t ___Data;
};
struct RawData_t37CAF2D3F74B7723974ED7CEEE9B297D8FA64ED0_marshaled_com
{
	intptr_t ___Bounds;
	intptr_t ___Count;
	uint8_t ___Data;
};
struct Span_1_t087F0E3724EBFD3A74A84E3F9E3F027249F37B51 
{
	ByReference_1_t98C4399D749F9F8F828547057023CF78951E6126 ____pointer;
	int32_t ____length;
};
struct MulticastDelegate_t  : public Delegate_t
{
	DelegateU5BU5D_tC5AB7E8F745616680F337909D3A8E6C722CDF771* ___delegates;
};
struct MulticastDelegate_t_marshaled_pinvoke : public Delegate_t_marshaled_pinvoke
{
	Delegate_t_marshaled_pinvoke** ___delegates;
};
struct MulticastDelegate_t_marshaled_com : public Delegate_t_marshaled_com
{
	Delegate_t_marshaled_com** ___delegates;
};
struct NotifyCollectionChangedEventArgs_tFF32515F3E2B116CAB376B5B57C6A8CB617351FA  : public EventArgs_t37273F03EAC87217701DD431B190FBD84AD7C377
{
	int32_t ____action;
	RuntimeObject* ____newItems;
	RuntimeObject* ____oldItems;
	int32_t ____newStartingIndex;
	int32_t ____oldStartingIndex;
};
struct SynchronizationContext_tCDB842BBE53B050802CBBB59C6E6DC45B5B06DC0  : public RuntimeObject
{
	int32_t ____props;
};
struct SystemException_tCC48D868298F4C0705279823E34B00F4FBDB7295  : public Exception_t
{
};
struct Type_t  : public MemberInfo_t
{
	RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B ____impl;
};
struct Action_1_t4886BB533893363037886031AFA3134F2BE506A0  : public MulticastDelegate_t
{
};
struct Action_1_t6F9EB113EB3F16226AEF811A2744F4111C116C87  : public MulticastDelegate_t
{
};
struct Func_1_t8C8AB5C3244441F8D3FD536FF3DC2BB60FD22F87  : public MulticastDelegate_t
{
};
struct CollectionEventDispatcherEventArgs_t897929345863379302C0A2FDAF37F55BA7247339  : public NotifyCollectionChangedEventArgs_tFF32515F3E2B116CAB376B5B57C6A8CB617351FA
{
	RuntimeObject* ___U3CCollectionU3Ek__BackingField;
	bool ___U3CIsInvokeCollectionChangedU3Ek__BackingField;
	bool ___U3CIsInvokePropertyChangedU3Ek__BackingField;
	Action_1_t4886BB533893363037886031AFA3134F2BE506A0* ___U3CInvokerU3Ek__BackingField;
};
struct FixedBoolArray_tC32093C6C050FB8FAA864BD206C0A2C3F5A9003A 
{
	Span_1_t087F0E3724EBFD3A74A84E3F9E3F027249F37B51 ___Span;
	BooleanU5BU5D_tD317D27C31DB892BE79FAE3AEBC0B3FFB73DE9B4* ___array;
};
struct FixedBoolArray_tC32093C6C050FB8FAA864BD206C0A2C3F5A9003A_marshaled_pinvoke
{
	Span_1_t087F0E3724EBFD3A74A84E3F9E3F027249F37B51 ___Span;
	int32_t* ___array;
};
struct FixedBoolArray_tC32093C6C050FB8FAA864BD206C0A2C3F5A9003A_marshaled_com
{
	Span_1_t087F0E3724EBFD3A74A84E3F9E3F027249F37B51 ___Span;
	int32_t* ___array;
};
struct InvalidOperationException_t5DDE4D49B7405FAAB1E4576F4715A42A3FAD4BAB  : public SystemException_tCC48D868298F4C0705279823E34B00F4FBDB7295
{
};
struct SendOrPostCallback_t5C292A12062F24027A98492F52ECFE9802AA6F0E  : public MulticastDelegate_t
{
};
struct ArrayPool_1_tA078350A0D495C7FFCFF5BF612FA605A894B24F7_StaticFields
{
	ArrayPool_1_tA078350A0D495C7FFCFF5BF612FA605A894B24F7* ___U3CSharedU3Ek__BackingField;
};
struct InlineCollectionEventDispatcher_t6C5003C831CE0A044CB873B6A3058B992900D761_StaticFields
{
	RuntimeObject* ___Instance;
};
struct String_t_StaticFields
{
	String_t* ___Empty;
};
struct SynchronizationContextCollectionEventDispatcher_tD0A54D5AF16049B806210282D1017E5DFF3108A9_StaticFields
{
	Lazy_1_tFDCCF60E5E7B218CA86C19EE6C5DDE4FEC239292* ___current;
	RuntimeObject* ___Current;
	SendOrPostCallback_t5C292A12062F24027A98492F52ECFE9802AA6F0E* ___callback;
};
struct U3CU3Ec_tD3BCC22757396379C0AF60029CE9F7011891CDB7_StaticFields
{
	U3CU3Ec_tD3BCC22757396379C0AF60029CE9F7011891CDB7* ___U3CU3E9;
};
struct Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_StaticFields
{
	String_t* ___TrueString;
	String_t* ___FalseString;
};
struct IntPtr_t_StaticFields
{
	intptr_t ___Zero;
};
struct Type_t_StaticFields
{
	Binder_t91BFCE95A7057FADF4D8A1A342AFE52872246235* ___s_defaultBinder;
	Il2CppChar ___Delimiter;
	TypeU5BU5D_t97234E1129B564EB38B8D85CAC2AD8B5B9522FFB* ___EmptyTypes;
	RuntimeObject* ___Missing;
	MemberFilter_tF644F1AE82F611B677CE1964D5A3277DDA21D553* ___FilterAttribute;
	MemberFilter_tF644F1AE82F611B677CE1964D5A3277DDA21D553* ___FilterName;
	MemberFilter_tF644F1AE82F611B677CE1964D5A3277DDA21D553* ___FilterNameIgnoreCase;
};
#ifdef __clang__
#pragma clang diagnostic pop
#endif
struct ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031  : public RuntimeArray
{
	ALIGN_FIELD (8) uint8_t m_Items[1];

	inline uint8_t GetAt(il2cpp_array_size_t index) const
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items[index];
	}
	inline uint8_t* GetAddressAt(il2cpp_array_size_t index)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items + index;
	}
	inline void SetAt(il2cpp_array_size_t index, uint8_t value)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		m_Items[index] = value;
	}
	inline uint8_t GetAtUnchecked(il2cpp_array_size_t index) const
	{
		return m_Items[index];
	}
	inline uint8_t* GetAddressAtUnchecked(il2cpp_array_size_t index)
	{
		return m_Items + index;
	}
	inline void SetAtUnchecked(il2cpp_array_size_t index, uint8_t value)
	{
		m_Items[index] = value;
	}
};
struct StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248  : public RuntimeArray
{
	ALIGN_FIELD (8) String_t* m_Items[1];

	inline String_t* GetAt(il2cpp_array_size_t index) const
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items[index];
	}
	inline String_t** GetAddressAt(il2cpp_array_size_t index)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items + index;
	}
	inline void SetAt(il2cpp_array_size_t index, String_t* value)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier((void**)m_Items + index, (void*)value);
	}
	inline String_t* GetAtUnchecked(il2cpp_array_size_t index) const
	{
		return m_Items[index];
	}
	inline String_t** GetAddressAtUnchecked(il2cpp_array_size_t index)
	{
		return m_Items + index;
	}
	inline void SetAtUnchecked(il2cpp_array_size_t index, String_t* value)
	{
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier((void**)m_Items + index, (void*)value);
	}
};
struct ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918  : public RuntimeArray
{
	ALIGN_FIELD (8) RuntimeObject* m_Items[1];

	inline RuntimeObject* GetAt(il2cpp_array_size_t index) const
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items[index];
	}
	inline RuntimeObject** GetAddressAt(il2cpp_array_size_t index)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items + index;
	}
	inline void SetAt(il2cpp_array_size_t index, RuntimeObject* value)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier((void**)m_Items + index, (void*)value);
	}
	inline RuntimeObject* GetAtUnchecked(il2cpp_array_size_t index) const
	{
		return m_Items[index];
	}
	inline RuntimeObject** GetAddressAtUnchecked(il2cpp_array_size_t index)
	{
		return m_Items + index;
	}
	inline void SetAtUnchecked(il2cpp_array_size_t index, RuntimeObject* value)
	{
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier((void**)m_Items + index, (void*)value);
	}
};
struct BooleanU5BU5D_tD317D27C31DB892BE79FAE3AEBC0B3FFB73DE9B4  : public RuntimeArray
{
	ALIGN_FIELD (8) bool m_Items[1];

	inline bool GetAt(il2cpp_array_size_t index) const
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items[index];
	}
	inline bool* GetAddressAt(il2cpp_array_size_t index)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items + index;
	}
	inline void SetAt(il2cpp_array_size_t index, bool value)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		m_Items[index] = value;
	}
	inline bool GetAtUnchecked(il2cpp_array_size_t index) const
	{
		return m_Items[index];
	}
	inline bool* GetAddressAtUnchecked(il2cpp_array_size_t index)
	{
		return m_Items + index;
	}
	inline void SetAtUnchecked(il2cpp_array_size_t index, bool value)
	{
		m_Items[index] = value;
	}
};


IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Func_1__ctor_m663374A863E492A515BE9626B6F0E444991834E8_gshared (Func_1_tD5C081AE11746B200C711DD48DBEB00E3A9276D4* __this, RuntimeObject* ___0_object, intptr_t ___1_method, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Lazy_1__ctor_m4CD0C5ACC0541018DB9BDB090B1EFE67D5A9CEF1_gshared (Lazy_1_tAD66CD7CC97BB996411F4FE0F49A1817031B906E* __this, Func_1_tD5C081AE11746B200C711DD48DBEB00E3A9276D4* ___0_valueFactory, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* Lazy_1_get_Value_mC3D475ED3C0FAB4E8BCC96FBF5EF49ED671B86A4_gshared (Lazy_1_tAD66CD7CC97BB996411F4FE0F49A1817031B906E* __this, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Action_1_Invoke_mF2422B2DD29F74CE66F791C3F68E288EC7C3DB9E_gshared_inline (Action_1_t6F9EB113EB3F16226AEF811A2744F4111C116C87* __this, RuntimeObject* ___0_obj, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t Span_1_get_Length_mED1253429B93CB6D2928015A22105A16FF64C86B_gshared_inline (Span_1_t087F0E3724EBFD3A74A84E3F9E3F027249F37B51* __this, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR ArrayPool_1_tA078350A0D495C7FFCFF5BF612FA605A894B24F7* ArrayPool_1_get_Shared_m4880204C02055CC88D825651B2940134A9F99C35_gshared_inline (const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Span_1_t087F0E3724EBFD3A74A84E3F9E3F027249F37B51 MemoryExtensions_AsSpan_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_m4B450C631366925983E48616CE396F35E694835D_gshared_inline (BooleanU5BU5D_tD317D27C31DB892BE79FAE3AEBC0B3FFB73DE9B4* ___0_array, int32_t ___1_start, int32_t ___2_length, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Span_1__ctor_mF010B57B13C6597DA14D7957BD2E07090F8336A6_gshared_inline (Span_1_t087F0E3724EBFD3A74A84E3F9E3F027249F37B51* __this, BooleanU5BU5D_tD317D27C31DB892BE79FAE3AEBC0B3FFB73DE9B4* ___0_array, int32_t ___1_start, int32_t ___2_length, const RuntimeMethod* method) ;

IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Attribute__ctor_m79ED1BF1EE36D1E417BA89A0D9F91F8AAD8D19E2 (Attribute_tFDA8EFEFB0711976D22474794576DAF28F7440AA* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Object__ctor_mE837C6B9FA8C6D5D109F4B2EC885D79919AC0EA2 (RuntimeObject* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR SynchronizationContext_tCDB842BBE53B050802CBBB59C6E6DC45B5B06DC0* SynchronizationContext_get_Current_m8DE6D3020745B7955249A2470A23EC0ECBB02A82 (const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void SendOrPostCallback_Invoke_m23B949AF9D78E8635F84E1E7775A50472B4F9C28_inline (SendOrPostCallback_t5C292A12062F24027A98492F52ECFE9802AA6F0E* __this, RuntimeObject* ___0_state, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void CollectionEventDispatcherEventArgs_Invoke_mA3D48E82E2A707789B0BD50199E828D8B623D343 (CollectionEventDispatcherEventArgs_t897929345863379302C0A2FDAF37F55BA7247339* __this, const RuntimeMethod* method) ;
inline void Func_1__ctor_m8F76037F1B0E7D7A69BE711AFEFF02AB38527CEB (Func_1_t8C8AB5C3244441F8D3FD536FF3DC2BB60FD22F87* __this, RuntimeObject* ___0_object, intptr_t ___1_method, const RuntimeMethod* method)
{
	((  void (*) (Func_1_t8C8AB5C3244441F8D3FD536FF3DC2BB60FD22F87*, RuntimeObject*, intptr_t, const RuntimeMethod*))Func_1__ctor_m663374A863E492A515BE9626B6F0E444991834E8_gshared)(__this, ___0_object, ___1_method, method);
}
inline void Lazy_1__ctor_m6302B6ABC895FA85915F9773675C29AD11C7243C (Lazy_1_tFDCCF60E5E7B218CA86C19EE6C5DDE4FEC239292* __this, Func_1_t8C8AB5C3244441F8D3FD536FF3DC2BB60FD22F87* ___0_valueFactory, const RuntimeMethod* method)
{
	((  void (*) (Lazy_1_tFDCCF60E5E7B218CA86C19EE6C5DDE4FEC239292*, Func_1_t8C8AB5C3244441F8D3FD536FF3DC2BB60FD22F87*, const RuntimeMethod*))Lazy_1__ctor_m4CD0C5ACC0541018DB9BDB090B1EFE67D5A9CEF1_gshared)(__this, ___0_valueFactory, method);
}
inline RuntimeObject* Lazy_1_get_Value_mF4F983F782F878359F3120BA280C70276FED6536 (Lazy_1_tFDCCF60E5E7B218CA86C19EE6C5DDE4FEC239292* __this, const RuntimeMethod* method)
{
	return ((  RuntimeObject* (*) (Lazy_1_tFDCCF60E5E7B218CA86C19EE6C5DDE4FEC239292*, const RuntimeMethod*))Lazy_1_get_Value_mC3D475ED3C0FAB4E8BCC96FBF5EF49ED671B86A4_gshared)(__this, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void SendOrPostCallback__ctor_mE6F9D9606A00C3C18AEA057422ECF4106C80DA37 (SendOrPostCallback_t5C292A12062F24027A98492F52ECFE9802AA6F0E* __this, RuntimeObject* ___0_object, intptr_t ___1_method, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void U3CU3Ec__ctor_mB16A67FB3B05A0BFA173F0B969DA418393672D4C (U3CU3Ec_tD3BCC22757396379C0AF60029CE9F7011891CDB7* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void InvalidOperationException__ctor_mE4CB6F4712AB6D99A2358FBAE2E052B3EE976162 (InvalidOperationException_t5DDE4D49B7405FAAB1E4576F4715A42A3FAD4BAB* __this, String_t* ___0_message, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void SynchronizationContextCollectionEventDispatcher__ctor_m77B04E33F10CCD9B01631CAA62A1296E883DC831 (SynchronizationContextCollectionEventDispatcher_tD0A54D5AF16049B806210282D1017E5DFF3108A9* __this, SynchronizationContext_tCDB842BBE53B050802CBBB59C6E6DC45B5B06DC0* ___0_synchronizationContext, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void InlineCollectionEventDispatcher__ctor_m91C50DF243DD89CDAA915C9CBAD933A9461ED64A (InlineCollectionEventDispatcher_t6C5003C831CE0A044CB873B6A3058B992900D761* __this, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Action_1_t4886BB533893363037886031AFA3134F2BE506A0* CollectionEventDispatcherEventArgs_get_Invoker_m85B5EDE12797490123B2F37090EC1DAF5898D33D_inline (CollectionEventDispatcherEventArgs_t897929345863379302C0A2FDAF37F55BA7247339* __this, const RuntimeMethod* method) ;
inline void Action_1_Invoke_m958803F460E839AA5E59C3FEA4D23188B1B22365_inline (Action_1_t4886BB533893363037886031AFA3134F2BE506A0* __this, CollectionEventDispatcherEventArgs_t897929345863379302C0A2FDAF37F55BA7247339* ___0_obj, const RuntimeMethod* method)
{
	((  void (*) (Action_1_t4886BB533893363037886031AFA3134F2BE506A0*, CollectionEventDispatcherEventArgs_t897929345863379302C0A2FDAF37F55BA7247339*, const RuntimeMethod*))Action_1_Invoke_mF2422B2DD29F74CE66F791C3F68E288EC7C3DB9E_gshared_inline)(__this, ___0_obj, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NotifyCollectionChangedEventArgs__ctor_m1EE75703595F07CE93EFC0861AAE02EE9B3AC823 (NotifyCollectionChangedEventArgs_tFF32515F3E2B116CAB376B5B57C6A8CB617351FA* __this, int32_t ___0_action, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NotifyCollectionChangedEventArgs__ctor_m94EF19F0CEA17A580708E067B4553B8683DE70DE (NotifyCollectionChangedEventArgs_tFF32515F3E2B116CAB376B5B57C6A8CB617351FA* __this, int32_t ___0_action, RuntimeObject* ___1_changedItems, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NotifyCollectionChangedEventArgs__ctor_mA0FDC21EB566901D817C29A859B930FF28968158 (NotifyCollectionChangedEventArgs_tFF32515F3E2B116CAB376B5B57C6A8CB617351FA* __this, int32_t ___0_action, RuntimeObject* ___1_changedItem, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NotifyCollectionChangedEventArgs__ctor_mBFD6D3F3F7E50F8D7E6B6C005DC983BD8F4FEB0D (NotifyCollectionChangedEventArgs_tFF32515F3E2B116CAB376B5B57C6A8CB617351FA* __this, int32_t ___0_action, RuntimeObject* ___1_newItems, RuntimeObject* ___2_oldItems, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NotifyCollectionChangedEventArgs__ctor_m8D4BE63EF4D5570DDA84FE7449C12358CE22FC9F (NotifyCollectionChangedEventArgs_tFF32515F3E2B116CAB376B5B57C6A8CB617351FA* __this, int32_t ___0_action, RuntimeObject* ___1_changedItems, int32_t ___2_startingIndex, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NotifyCollectionChangedEventArgs__ctor_m010974C04F22D47110DCD77005CA026F7EA2F7B7 (NotifyCollectionChangedEventArgs_tFF32515F3E2B116CAB376B5B57C6A8CB617351FA* __this, int32_t ___0_action, RuntimeObject* ___1_changedItem, int32_t ___2_index, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NotifyCollectionChangedEventArgs__ctor_m3BF1219EE3A15FCF07D54BD727F74EAB6D0EC785 (NotifyCollectionChangedEventArgs_tFF32515F3E2B116CAB376B5B57C6A8CB617351FA* __this, int32_t ___0_action, RuntimeObject* ___1_newItem, RuntimeObject* ___2_oldItem, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NotifyCollectionChangedEventArgs__ctor_m58DB02BBDF35CCB817A0635AEBA6592C8167F49C (NotifyCollectionChangedEventArgs_tFF32515F3E2B116CAB376B5B57C6A8CB617351FA* __this, int32_t ___0_action, RuntimeObject* ___1_newItems, RuntimeObject* ___2_oldItems, int32_t ___3_startingIndex, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NotifyCollectionChangedEventArgs__ctor_m5D106E40619F1A2C1804767917CCA4885EF02D3E (NotifyCollectionChangedEventArgs_tFF32515F3E2B116CAB376B5B57C6A8CB617351FA* __this, int32_t ___0_action, RuntimeObject* ___1_changedItems, int32_t ___2_index, int32_t ___3_oldIndex, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NotifyCollectionChangedEventArgs__ctor_m4C36BCE7D7E31A5A659E5770024C202216EB36AE (NotifyCollectionChangedEventArgs_tFF32515F3E2B116CAB376B5B57C6A8CB617351FA* __this, int32_t ___0_action, RuntimeObject* ___1_changedItem, int32_t ___2_index, int32_t ___3_oldIndex, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NotifyCollectionChangedEventArgs__ctor_m839DE4731C24001AE7820BFE9F7B56DC05CE1CD3 (NotifyCollectionChangedEventArgs_tFF32515F3E2B116CAB376B5B57C6A8CB617351FA* __this, int32_t ___0_action, RuntimeObject* ___1_newItem, RuntimeObject* ___2_oldItem, int32_t ___3_index, const RuntimeMethod* method) ;
inline int32_t Span_1_get_Length_mED1253429B93CB6D2928015A22105A16FF64C86B_inline (Span_1_t087F0E3724EBFD3A74A84E3F9E3F027249F37B51* __this, const RuntimeMethod* method)
{
	return ((  int32_t (*) (Span_1_t087F0E3724EBFD3A74A84E3F9E3F027249F37B51*, const RuntimeMethod*))Span_1_get_Length_mED1253429B93CB6D2928015A22105A16FF64C86B_gshared_inline)(__this, method);
}
inline ArrayPool_1_tA078350A0D495C7FFCFF5BF612FA605A894B24F7* ArrayPool_1_get_Shared_m4880204C02055CC88D825651B2940134A9F99C35_inline (const RuntimeMethod* method)
{
	return ((  ArrayPool_1_tA078350A0D495C7FFCFF5BF612FA605A894B24F7* (*) (const RuntimeMethod*))ArrayPool_1_get_Shared_m4880204C02055CC88D825651B2940134A9F99C35_gshared_inline)(method);
}
inline Span_1_t087F0E3724EBFD3A74A84E3F9E3F027249F37B51 MemoryExtensions_AsSpan_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_m4B450C631366925983E48616CE396F35E694835D_inline (BooleanU5BU5D_tD317D27C31DB892BE79FAE3AEBC0B3FFB73DE9B4* ___0_array, int32_t ___1_start, int32_t ___2_length, const RuntimeMethod* method)
{
	return ((  Span_1_t087F0E3724EBFD3A74A84E3F9E3F027249F37B51 (*) (BooleanU5BU5D_tD317D27C31DB892BE79FAE3AEBC0B3FFB73DE9B4*, int32_t, int32_t, const RuntimeMethod*))MemoryExtensions_AsSpan_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_m4B450C631366925983E48616CE396F35E694835D_gshared_inline)(___0_array, ___1_start, ___2_length, method);
}
inline void Span_1__ctor_mF010B57B13C6597DA14D7957BD2E07090F8336A6_inline (Span_1_t087F0E3724EBFD3A74A84E3F9E3F027249F37B51* __this, BooleanU5BU5D_tD317D27C31DB892BE79FAE3AEBC0B3FFB73DE9B4* ___0_array, int32_t ___1_start, int32_t ___2_length, const RuntimeMethod* method)
{
	((  void (*) (Span_1_t087F0E3724EBFD3A74A84E3F9E3F027249F37B51*, BooleanU5BU5D_tD317D27C31DB892BE79FAE3AEBC0B3FFB73DE9B4*, int32_t, int32_t, const RuntimeMethod*))Span_1__ctor_mF010B57B13C6597DA14D7957BD2E07090F8336A6_gshared_inline)(__this, ___0_array, ___1_start, ___2_length, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ThrowHelper_ThrowArgumentOutOfRangeException_mD7D90276EDCDF9394A8EA635923E3B48BB71BD56 (const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR uint8_t* Array_GetRawSzArrayData_m2F8F5B2A381AEF971F12866D9C0A6C4FBA59F6BB_inline (RuntimeArray* __this, const RuntimeMethod* method) ;
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// Method Definition Index: 71832
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void EmbeddedAttribute__ctor_mA5D98EB20BDB326409B1F78ACAB721B58A08A4BA (EmbeddedAttribute_tB3AA6A121F64C34903793F66EFADF13D69D84243* __this, const RuntimeMethod* method) 
{
	{
		Attribute__ctor_m79ED1BF1EE36D1E417BA89A0D9F91F8AAD8D19E2(__this, NULL);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// Method Definition Index: 71833
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NullableAttribute__ctor_m515FD90819494D43C24A2005042324A02F7935D9 (NullableAttribute_t9A0E8C2E8A6F4BEC0A70CC54F3279B3E415C4914* __this, uint8_t ___0_p, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		Attribute__ctor_m79ED1BF1EE36D1E417BA89A0D9F91F8AAD8D19E2(__this, NULL);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_0 = (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*)(ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*)SZArrayNew(ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031_il2cpp_TypeInfo_var, (uint32_t)1);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_1 = L_0;
		uint8_t L_2 = ___0_p;
		NullCheck(L_1);
		(L_1)->SetAt(static_cast<il2cpp_array_size_t>(0), (uint8_t)L_2);
		__this->___NullableFlags = L_1;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___NullableFlags), (void*)L_1);
		return;
	}
}
// Method Definition Index: 71834
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NullableAttribute__ctor_mE94C8CD83DAEAD45FE15ED47E574DF2D00B14DE5 (NullableAttribute_t9A0E8C2E8A6F4BEC0A70CC54F3279B3E415C4914* __this, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___0_p, const RuntimeMethod* method) 
{
	{
		Attribute__ctor_m79ED1BF1EE36D1E417BA89A0D9F91F8AAD8D19E2(__this, NULL);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_0 = ___0_p;
		__this->___NullableFlags = L_0;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___NullableFlags), (void*)L_0);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// Method Definition Index: 71835
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NullableContextAttribute__ctor_m45455F0494DFA7C06997CDF6D2C9097342F3913A (NullableContextAttribute_tEB43CD155472303BE2B5557D07B65ED056B0BD16* __this, uint8_t ___0_p, const RuntimeMethod* method) 
{
	{
		Attribute__ctor_m79ED1BF1EE36D1E417BA89A0D9F91F8AAD8D19E2(__this, NULL);
		uint8_t L_0 = ___0_p;
		__this->___Flag = L_0;
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// Method Definition Index: 71836
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void RefSafetyRulesAttribute__ctor_mD300C03B302C780D1908DCAFBD1572EC90950810 (RefSafetyRulesAttribute_t5898C461874BCE9DD3DC7B3A2499589F869A7051* __this, int32_t ___0_p, const RuntimeMethod* method) 
{
	{
		Attribute__ctor_m79ED1BF1EE36D1E417BA89A0D9F91F8AAD8D19E2(__this, NULL);
		int32_t L_0 = ___0_p;
		__this->___Version = L_0;
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// Method Definition Index: 71837
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ExperimentalAttribute__ctor_m565622BF716A92657E0868C80B478FDB9B5B93FC (ExperimentalAttribute_t1DBB6B99498094652CE6971BD0C49000A306AB40* __this, String_t* ___0_diagnosticId, const RuntimeMethod* method) 
{
	{
		Attribute__ctor_m79ED1BF1EE36D1E417BA89A0D9F91F8AAD8D19E2(__this, NULL);
		String_t* L_0 = ___0_diagnosticId;
		__this->___U3CDiagnosticIdU3Ek__BackingField = L_0;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___U3CDiagnosticIdU3Ek__BackingField), (void*)L_0);
		return;
	}
}
// Method Definition Index: 71838
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* ExperimentalAttribute_get_DiagnosticId_m53A716F5BC767E134E720C454DA713427CE56218 (ExperimentalAttribute_t1DBB6B99498094652CE6971BD0C49000A306AB40* __this, const RuntimeMethod* method) 
{
	{
		String_t* L_0 = __this->___U3CDiagnosticIdU3Ek__BackingField;
		return L_0;
	}
}
// Method Definition Index: 71839
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* ExperimentalAttribute_get_UrlFormat_mCF207BBD092490A7DABE2B1C0342C9B8F8620CDE (ExperimentalAttribute_t1DBB6B99498094652CE6971BD0C49000A306AB40* __this, const RuntimeMethod* method) 
{
	{
		String_t* L_0 = __this->___U3CUrlFormatU3Ek__BackingField;
		return L_0;
	}
}
// Method Definition Index: 71840
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ExperimentalAttribute_set_UrlFormat_mA3EC05CB2F74A4D976FF9701F6F45270D05C619E (ExperimentalAttribute_t1DBB6B99498094652CE6971BD0C49000A306AB40* __this, String_t* ___0_value, const RuntimeMethod* method) 
{
	{
		String_t* L_0 = ___0_value;
		__this->___U3CUrlFormatU3Ek__BackingField = L_0;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___U3CUrlFormatU3Ek__BackingField), (void*)L_0);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// Method Definition Index: 71841
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MemberNotNullAttribute__ctor_m8BD5476744A9D324FAF80A98D0061AB121A2F741 (MemberNotNullAttribute_tA7E83A64A957FC6B520A7C96CCECE5DC95274913* __this, String_t* ___0_member, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		Attribute__ctor_m79ED1BF1EE36D1E417BA89A0D9F91F8AAD8D19E2(__this, NULL);
		StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248* L_0 = (StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248*)(StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248*)SZArrayNew(StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248_il2cpp_TypeInfo_var, (uint32_t)1);
		StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248* L_1 = L_0;
		String_t* L_2 = ___0_member;
		NullCheck(L_1);
		(L_1)->SetAt(static_cast<il2cpp_array_size_t>(0), (String_t*)L_2);
		__this->___U3CMembersU3Ek__BackingField = L_1;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___U3CMembersU3Ek__BackingField), (void*)L_1);
		return;
	}
}
// Method Definition Index: 71842
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MemberNotNullAttribute__ctor_m6FFB5AA9EFC7A934CD23D5F684FC64CFAAA17898 (MemberNotNullAttribute_tA7E83A64A957FC6B520A7C96CCECE5DC95274913* __this, StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248* ___0_members, const RuntimeMethod* method) 
{
	{
		Attribute__ctor_m79ED1BF1EE36D1E417BA89A0D9F91F8AAD8D19E2(__this, NULL);
		StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248* L_0 = ___0_members;
		__this->___U3CMembersU3Ek__BackingField = L_0;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___U3CMembersU3Ek__BackingField), (void*)L_0);
		return;
	}
}
// Method Definition Index: 71843
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248* MemberNotNullAttribute_get_Members_mFA5F78DF85AA08A3F5F4E44147E61C5EA00B40CA (MemberNotNullAttribute_tA7E83A64A957FC6B520A7C96CCECE5DC95274913* __this, const RuntimeMethod* method) 
{
	{
		StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248* L_0 = __this->___U3CMembersU3Ek__BackingField;
		return L_0;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// Method Definition Index: 71844
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MemberNotNullWhenAttribute__ctor_mADFBE1918F1F276132E47019C94EB6BB04CF5F7B (MemberNotNullWhenAttribute_tD97AA77F62B1B44576483DFF7E3419171D10ED23* __this, bool ___0_returnValue, String_t* ___1_member, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		Attribute__ctor_m79ED1BF1EE36D1E417BA89A0D9F91F8AAD8D19E2(__this, NULL);
		bool L_0 = ___0_returnValue;
		__this->___U3CReturnValueU3Ek__BackingField = L_0;
		StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248* L_1 = (StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248*)(StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248*)SZArrayNew(StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248_il2cpp_TypeInfo_var, (uint32_t)1);
		StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248* L_2 = L_1;
		String_t* L_3 = ___1_member;
		NullCheck(L_2);
		(L_2)->SetAt(static_cast<il2cpp_array_size_t>(0), (String_t*)L_3);
		__this->___U3CMembersU3Ek__BackingField = L_2;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___U3CMembersU3Ek__BackingField), (void*)L_2);
		return;
	}
}
// Method Definition Index: 71845
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MemberNotNullWhenAttribute__ctor_mEAAC45322E78807326BFE28263EE52F18CA0F680 (MemberNotNullWhenAttribute_tD97AA77F62B1B44576483DFF7E3419171D10ED23* __this, bool ___0_returnValue, StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248* ___1_members, const RuntimeMethod* method) 
{
	{
		Attribute__ctor_m79ED1BF1EE36D1E417BA89A0D9F91F8AAD8D19E2(__this, NULL);
		bool L_0 = ___0_returnValue;
		__this->___U3CReturnValueU3Ek__BackingField = L_0;
		StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248* L_1 = ___1_members;
		__this->___U3CMembersU3Ek__BackingField = L_1;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___U3CMembersU3Ek__BackingField), (void*)L_1);
		return;
	}
}
// Method Definition Index: 71846
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool MemberNotNullWhenAttribute_get_ReturnValue_m6C6F302226290183CB33CBBA2697DDABBA3714D7 (MemberNotNullWhenAttribute_tD97AA77F62B1B44576483DFF7E3419171D10ED23* __this, const RuntimeMethod* method) 
{
	{
		bool L_0 = __this->___U3CReturnValueU3Ek__BackingField;
		return L_0;
	}
}
// Method Definition Index: 71847
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248* MemberNotNullWhenAttribute_get_Members_mDC9B687BCFA081C4FF1F79DFEB79CB7DC433B00D (MemberNotNullWhenAttribute_tD97AA77F62B1B44576483DFF7E3419171D10ED23* __this, const RuntimeMethod* method) 
{
	{
		StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248* L_0 = __this->___U3CMembersU3Ek__BackingField;
		return L_0;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// Method Definition Index: 71848
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void SetsRequiredMembersAttribute__ctor_m8858A7926E943DB8C1CECDC663D18FF3A721B7E7 (SetsRequiredMembersAttribute_t6DA5C73E07B0708646CA8B49A79E43DC6D7760B6* __this, const RuntimeMethod* method) 
{
	{
		Attribute__ctor_m79ED1BF1EE36D1E417BA89A0D9F91F8AAD8D19E2(__this, NULL);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// Method Definition Index: 71849
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void StringSyntaxAttribute__ctor_m474498CB21757F5C554456C0826C8A91DB3471D8 (StringSyntaxAttribute_t5016B3EF90D82CE59E1CD3CD6AF9F4053A3CFE68* __this, String_t* ___0_syntax, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		Attribute__ctor_m79ED1BF1EE36D1E417BA89A0D9F91F8AAD8D19E2(__this, NULL);
		String_t* L_0 = ___0_syntax;
		__this->___U3CSyntaxU3Ek__BackingField = L_0;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___U3CSyntaxU3Ek__BackingField), (void*)L_0);
		ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918* L_1 = (ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918*)(ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918*)SZArrayNew(ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918_il2cpp_TypeInfo_var, (uint32_t)0);
		__this->___U3CArgumentsU3Ek__BackingField = L_1;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___U3CArgumentsU3Ek__BackingField), (void*)L_1);
		return;
	}
}
// Method Definition Index: 71850
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void StringSyntaxAttribute__ctor_m69A091C142E00CE7BEC094BAE96B6AEAB0A88CAF (StringSyntaxAttribute_t5016B3EF90D82CE59E1CD3CD6AF9F4053A3CFE68* __this, String_t* ___0_syntax, ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918* ___1_arguments, const RuntimeMethod* method) 
{
	{
		Attribute__ctor_m79ED1BF1EE36D1E417BA89A0D9F91F8AAD8D19E2(__this, NULL);
		String_t* L_0 = ___0_syntax;
		__this->___U3CSyntaxU3Ek__BackingField = L_0;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___U3CSyntaxU3Ek__BackingField), (void*)L_0);
		ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918* L_1 = ___1_arguments;
		__this->___U3CArgumentsU3Ek__BackingField = L_1;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___U3CArgumentsU3Ek__BackingField), (void*)L_1);
		return;
	}
}
// Method Definition Index: 71851
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* StringSyntaxAttribute_get_Syntax_m598125C17C8F1083F434869ED60E83BE8FA9905B (StringSyntaxAttribute_t5016B3EF90D82CE59E1CD3CD6AF9F4053A3CFE68* __this, const RuntimeMethod* method) 
{
	{
		String_t* L_0 = __this->___U3CSyntaxU3Ek__BackingField;
		return L_0;
	}
}
// Method Definition Index: 71852
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918* StringSyntaxAttribute_get_Arguments_mF822AE5EFB6EBEDCC299CBA628F1AFD1A2BCDB63 (StringSyntaxAttribute_t5016B3EF90D82CE59E1CD3CD6AF9F4053A3CFE68* __this, const RuntimeMethod* method) 
{
	{
		ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918* L_0 = __this->___U3CArgumentsU3Ek__BackingField;
		return L_0;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// Method Definition Index: 71853
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnscopedRefAttribute__ctor_mC4D65AD152A8869113E254F5E0B8B0C47997BF85 (UnscopedRefAttribute_tA2C91E96C25BDF07D6891F9FA9990C8E4CE5B38B* __this, const RuntimeMethod* method) 
{
	{
		Attribute__ctor_m79ED1BF1EE36D1E417BA89A0D9F91F8AAD8D19E2(__this, NULL);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// Method Definition Index: 71854
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void RequiresPreviewFeaturesAttribute__ctor_m2AA67E199198FD57BF2216B1E291A7760A7EFC26 (RequiresPreviewFeaturesAttribute_tAE740C3CCA0F8D10D5F5AA35EA55111023DFADB2* __this, const RuntimeMethod* method) 
{
	{
		Attribute__ctor_m79ED1BF1EE36D1E417BA89A0D9F91F8AAD8D19E2(__this, NULL);
		return;
	}
}
// Method Definition Index: 71855
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void RequiresPreviewFeaturesAttribute__ctor_mB76930D1802570C6EC9144CD7910F2DCB53987F0 (RequiresPreviewFeaturesAttribute_tAE740C3CCA0F8D10D5F5AA35EA55111023DFADB2* __this, String_t* ___0_message, const RuntimeMethod* method) 
{
	{
		Attribute__ctor_m79ED1BF1EE36D1E417BA89A0D9F91F8AAD8D19E2(__this, NULL);
		String_t* L_0 = ___0_message;
		__this->___U3CMessageU3Ek__BackingField = L_0;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___U3CMessageU3Ek__BackingField), (void*)L_0);
		return;
	}
}
// Method Definition Index: 71856
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* RequiresPreviewFeaturesAttribute_get_Message_m3CAFE6B770FBD0DC51967FADF11134C68E9C8B3A (RequiresPreviewFeaturesAttribute_tAE740C3CCA0F8D10D5F5AA35EA55111023DFADB2* __this, const RuntimeMethod* method) 
{
	{
		String_t* L_0 = __this->___U3CMessageU3Ek__BackingField;
		return L_0;
	}
}
// Method Definition Index: 71857
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* RequiresPreviewFeaturesAttribute_get_Url_mCE094D2215DDD7DA048DD09EC4984570585166A2 (RequiresPreviewFeaturesAttribute_tAE740C3CCA0F8D10D5F5AA35EA55111023DFADB2* __this, const RuntimeMethod* method) 
{
	{
		String_t* L_0 = __this->___U3CUrlU3Ek__BackingField;
		return L_0;
	}
}
// Method Definition Index: 71858
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void RequiresPreviewFeaturesAttribute_set_Url_m0F1438FCA2A5AA832BE886A8A226A8BC3DCE81D7 (RequiresPreviewFeaturesAttribute_tAE740C3CCA0F8D10D5F5AA35EA55111023DFADB2* __this, String_t* ___0_value, const RuntimeMethod* method) 
{
	{
		String_t* L_0 = ___0_value;
		__this->___U3CUrlU3Ek__BackingField = L_0;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___U3CUrlU3Ek__BackingField), (void*)L_0);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// Method Definition Index: 71860
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void CallerArgumentExpressionAttribute__ctor_m4F7219B05F2F23A0E91B14E340E2C1DFED6FB791 (CallerArgumentExpressionAttribute_tB1FD8CA0D06B5ACEC737C828D31B36A25C48F93F* __this, String_t* ___0_parameterName, const RuntimeMethod* method) 
{
	{
		Attribute__ctor_m79ED1BF1EE36D1E417BA89A0D9F91F8AAD8D19E2(__this, NULL);
		String_t* L_0 = ___0_parameterName;
		__this->___U3CParameterNameU3Ek__BackingField = L_0;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___U3CParameterNameU3Ek__BackingField), (void*)L_0);
		return;
	}
}
// Method Definition Index: 71861
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* CallerArgumentExpressionAttribute_get_ParameterName_mDC85C0C7E6ECBC326806AE2DE021D61197B5C614 (CallerArgumentExpressionAttribute_tB1FD8CA0D06B5ACEC737C828D31B36A25C48F93F* __this, const RuntimeMethod* method) 
{
	{
		String_t* L_0 = __this->___U3CParameterNameU3Ek__BackingField;
		return L_0;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// Method Definition Index: 71862
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void CollectionBuilderAttribute__ctor_mCED34CA08B7490D44FACEF44242E5C09E5518926 (CollectionBuilderAttribute_t0D128F8E3C653D54D529BEF107D59E2465C3F390* __this, Type_t* ___0_builderType, String_t* ___1_methodName, const RuntimeMethod* method) 
{
	{
		Attribute__ctor_m79ED1BF1EE36D1E417BA89A0D9F91F8AAD8D19E2(__this, NULL);
		Type_t* L_0 = ___0_builderType;
		__this->___U3CBuilderTypeU3Ek__BackingField = L_0;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___U3CBuilderTypeU3Ek__BackingField), (void*)L_0);
		String_t* L_1 = ___1_methodName;
		__this->___U3CMethodNameU3Ek__BackingField = L_1;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___U3CMethodNameU3Ek__BackingField), (void*)L_1);
		return;
	}
}
// Method Definition Index: 71863
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Type_t* CollectionBuilderAttribute_get_BuilderType_m5CC99E5B7987BFF1472FE25AC86CE78427353B69 (CollectionBuilderAttribute_t0D128F8E3C653D54D529BEF107D59E2465C3F390* __this, const RuntimeMethod* method) 
{
	{
		Type_t* L_0 = __this->___U3CBuilderTypeU3Ek__BackingField;
		return L_0;
	}
}
// Method Definition Index: 71864
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* CollectionBuilderAttribute_get_MethodName_mCBAEFE9CEED3868CCCD27D7236318806FFBF3B13 (CollectionBuilderAttribute_t0D128F8E3C653D54D529BEF107D59E2465C3F390* __this, const RuntimeMethod* method) 
{
	{
		String_t* L_0 = __this->___U3CMethodNameU3Ek__BackingField;
		return L_0;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// Method Definition Index: 71865
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void CompilerFeatureRequiredAttribute__ctor_m43FA691DF781BA86160C3FCFD6D915C8A58DFAA0 (CompilerFeatureRequiredAttribute_t5830197792FF240CE22E91AE211F4F87F79A1C91* __this, String_t* ___0_featureName, const RuntimeMethod* method) 
{
	{
		Attribute__ctor_m79ED1BF1EE36D1E417BA89A0D9F91F8AAD8D19E2(__this, NULL);
		String_t* L_0 = ___0_featureName;
		__this->___U3CFeatureNameU3Ek__BackingField = L_0;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___U3CFeatureNameU3Ek__BackingField), (void*)L_0);
		return;
	}
}
// Method Definition Index: 71866
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* CompilerFeatureRequiredAttribute_get_FeatureName_m4C8CF71E35A4DED5880A74734CF7F907076CF327 (CompilerFeatureRequiredAttribute_t5830197792FF240CE22E91AE211F4F87F79A1C91* __this, const RuntimeMethod* method) 
{
	{
		String_t* L_0 = __this->___U3CFeatureNameU3Ek__BackingField;
		return L_0;
	}
}
// Method Definition Index: 71867
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool CompilerFeatureRequiredAttribute_get_IsOptional_mFBD34E19F4424AA41345E065C71551970E8E947E (CompilerFeatureRequiredAttribute_t5830197792FF240CE22E91AE211F4F87F79A1C91* __this, const RuntimeMethod* method) 
{
	{
		bool L_0 = __this->___U3CIsOptionalU3Ek__BackingField;
		return L_0;
	}
}
// Method Definition Index: 71868
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void CompilerFeatureRequiredAttribute_set_IsOptional_m73D12D4385A17B453B7482DD7C6892CBDE7100B8 (CompilerFeatureRequiredAttribute_t5830197792FF240CE22E91AE211F4F87F79A1C91* __this, bool ___0_value, const RuntimeMethod* method) 
{
	{
		bool L_0 = ___0_value;
		__this->___U3CIsOptionalU3Ek__BackingField = L_0;
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// Method Definition Index: 71869
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void InterpolatedStringHandlerArgumentAttribute__ctor_mBE51BE161EF910E6FA9F1CDE7A5B03190918AC48 (InterpolatedStringHandlerArgumentAttribute_tED51A430CF519FA32AB6A2750702B2A9E53AB750* __this, String_t* ___0_argument, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		Attribute__ctor_m79ED1BF1EE36D1E417BA89A0D9F91F8AAD8D19E2(__this, NULL);
		StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248* L_0 = (StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248*)(StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248*)SZArrayNew(StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248_il2cpp_TypeInfo_var, (uint32_t)1);
		StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248* L_1 = L_0;
		String_t* L_2 = ___0_argument;
		NullCheck(L_1);
		(L_1)->SetAt(static_cast<il2cpp_array_size_t>(0), (String_t*)L_2);
		__this->___U3CArgumentsU3Ek__BackingField = L_1;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___U3CArgumentsU3Ek__BackingField), (void*)L_1);
		return;
	}
}
// Method Definition Index: 71870
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void InterpolatedStringHandlerArgumentAttribute__ctor_mD81DA9AB0E549646D8D668EAFB05DDE54A35B88C (InterpolatedStringHandlerArgumentAttribute_tED51A430CF519FA32AB6A2750702B2A9E53AB750* __this, StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248* ___0_arguments, const RuntimeMethod* method) 
{
	{
		Attribute__ctor_m79ED1BF1EE36D1E417BA89A0D9F91F8AAD8D19E2(__this, NULL);
		StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248* L_0 = ___0_arguments;
		__this->___U3CArgumentsU3Ek__BackingField = L_0;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___U3CArgumentsU3Ek__BackingField), (void*)L_0);
		return;
	}
}
// Method Definition Index: 71871
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248* InterpolatedStringHandlerArgumentAttribute_get_Arguments_m6431ED8A1B6651A448CEF79635489AC08495513F (InterpolatedStringHandlerArgumentAttribute_tED51A430CF519FA32AB6A2750702B2A9E53AB750* __this, const RuntimeMethod* method) 
{
	{
		StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248* L_0 = __this->___U3CArgumentsU3Ek__BackingField;
		return L_0;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// Method Definition Index: 71872
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void InterpolatedStringHandlerAttribute__ctor_m8E9F48417CDF09C896D6B139A612A353C5FAA17D (InterpolatedStringHandlerAttribute_tD2D4F0E2ED6A3231C5DB88178D29F00B5902C74E* __this, const RuntimeMethod* method) 
{
	{
		Attribute__ctor_m79ED1BF1EE36D1E417BA89A0D9F91F8AAD8D19E2(__this, NULL);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// Method Definition Index: 71873
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ModuleInitializerAttribute__ctor_m0DBE6B0951108478F83B448D103B37325ED3C0E6 (ModuleInitializerAttribute_t2FF4CF8CAA5DDB62A007C08EF5E2AEF1B479F3D7* __this, const RuntimeMethod* method) 
{
	{
		Attribute__ctor_m79ED1BF1EE36D1E417BA89A0D9F91F8AAD8D19E2(__this, NULL);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// Method Definition Index: 71874
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void RequiredMemberAttribute__ctor_m5D03F40E3686240CA450EE10C36EE39B0CA15544 (RequiredMemberAttribute_t54CFC673EC99CC20400099B7A91C5D224FF6890B* __this, const RuntimeMethod* method) 
{
	{
		Attribute__ctor_m79ED1BF1EE36D1E417BA89A0D9F91F8AAD8D19E2(__this, NULL);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// Method Definition Index: 71875
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void RequiresLocationAttribute__ctor_mD68E772C9672D450BF5A87EA29E3AC186619FC41 (RequiresLocationAttribute_tF98B5396649241CB497A05F191708BA819095FF3* __this, const RuntimeMethod* method) 
{
	{
		Attribute__ctor_m79ED1BF1EE36D1E417BA89A0D9F91F8AAD8D19E2(__this, NULL);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// Method Definition Index: 71876
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void SkipLocalsInitAttribute__ctor_m79EF4B512D639A726D911C7E7C01C26EC729A70F (SkipLocalsInitAttribute_t8CFB142CB8317D704982FCF1DAD151079BF1F4F9* __this, const RuntimeMethod* method) 
{
	{
		Attribute__ctor_m79ED1BF1EE36D1E417BA89A0D9F91F8AAD8D19E2(__this, NULL);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// Method Definition Index: 71948
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void SynchronizationContextCollectionEventDispatcher__ctor_m77B04E33F10CCD9B01631CAA62A1296E883DC831 (SynchronizationContextCollectionEventDispatcher_tD0A54D5AF16049B806210282D1017E5DFF3108A9* __this, SynchronizationContext_tCDB842BBE53B050802CBBB59C6E6DC45B5B06DC0* ___0_synchronizationContext, const RuntimeMethod* method) 
{
	{
		Object__ctor_mE837C6B9FA8C6D5D109F4B2EC885D79919AC0EA2(__this, NULL);
		SynchronizationContext_tCDB842BBE53B050802CBBB59C6E6DC45B5B06DC0* L_0 = ___0_synchronizationContext;
		__this->___synchronizationContext = L_0;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___synchronizationContext), (void*)L_0);
		return;
	}
}
// Method Definition Index: 71949
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void SynchronizationContextCollectionEventDispatcher_Post_mF0570FEC84601C7FA17E5DBC443AB016418131D2 (SynchronizationContextCollectionEventDispatcher_tD0A54D5AF16049B806210282D1017E5DFF3108A9* __this, CollectionEventDispatcherEventArgs_t897929345863379302C0A2FDAF37F55BA7247339* ___0_ev, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&SynchronizationContextCollectionEventDispatcher_tD0A54D5AF16049B806210282D1017E5DFF3108A9_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		SynchronizationContext_tCDB842BBE53B050802CBBB59C6E6DC45B5B06DC0* L_0;
		L_0 = SynchronizationContext_get_Current_m8DE6D3020745B7955249A2470A23EC0ECBB02A82(NULL);
		if (L_0)
		{
			goto IL_0019;
		}
	}
	{
		SynchronizationContext_tCDB842BBE53B050802CBBB59C6E6DC45B5B06DC0* L_1 = __this->___synchronizationContext;
		il2cpp_codegen_runtime_class_init_inline(SynchronizationContextCollectionEventDispatcher_tD0A54D5AF16049B806210282D1017E5DFF3108A9_il2cpp_TypeInfo_var);
		SendOrPostCallback_t5C292A12062F24027A98492F52ECFE9802AA6F0E* L_2 = ((SynchronizationContextCollectionEventDispatcher_tD0A54D5AF16049B806210282D1017E5DFF3108A9_StaticFields*)il2cpp_codegen_static_fields_for(SynchronizationContextCollectionEventDispatcher_tD0A54D5AF16049B806210282D1017E5DFF3108A9_il2cpp_TypeInfo_var))->___callback;
		CollectionEventDispatcherEventArgs_t897929345863379302C0A2FDAF37F55BA7247339* L_3 = ___0_ev;
		NullCheck(L_1);
		VirtualActionInvoker2< SendOrPostCallback_t5C292A12062F24027A98492F52ECFE9802AA6F0E*, RuntimeObject* >::Invoke(5, L_1, L_2, L_3);
		return;
	}

IL_0019:
	{
		il2cpp_codegen_runtime_class_init_inline(SynchronizationContextCollectionEventDispatcher_tD0A54D5AF16049B806210282D1017E5DFF3108A9_il2cpp_TypeInfo_var);
		SendOrPostCallback_t5C292A12062F24027A98492F52ECFE9802AA6F0E* L_4 = ((SynchronizationContextCollectionEventDispatcher_tD0A54D5AF16049B806210282D1017E5DFF3108A9_StaticFields*)il2cpp_codegen_static_fields_for(SynchronizationContextCollectionEventDispatcher_tD0A54D5AF16049B806210282D1017E5DFF3108A9_il2cpp_TypeInfo_var))->___callback;
		CollectionEventDispatcherEventArgs_t897929345863379302C0A2FDAF37F55BA7247339* L_5 = ___0_ev;
		NullCheck(L_4);
		SendOrPostCallback_Invoke_m23B949AF9D78E8635F84E1E7775A50472B4F9C28_inline(L_4, L_5, NULL);
		return;
	}
}
// Method Definition Index: 71950
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void SynchronizationContextCollectionEventDispatcher_SendOrPostCallback_mD6486EAD82C0B2C3CE78E168A6436A9322C95009 (RuntimeObject* ___0_state, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&CollectionEventDispatcherEventArgs_t897929345863379302C0A2FDAF37F55BA7247339_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		RuntimeObject* L_0 = ___0_state;
		NullCheck(((CollectionEventDispatcherEventArgs_t897929345863379302C0A2FDAF37F55BA7247339*)CastclassClass((RuntimeObject*)L_0, CollectionEventDispatcherEventArgs_t897929345863379302C0A2FDAF37F55BA7247339_il2cpp_TypeInfo_var)));
		CollectionEventDispatcherEventArgs_Invoke_mA3D48E82E2A707789B0BD50199E828D8B623D343(((CollectionEventDispatcherEventArgs_t897929345863379302C0A2FDAF37F55BA7247339*)CastclassClass((RuntimeObject*)L_0, CollectionEventDispatcherEventArgs_t897929345863379302C0A2FDAF37F55BA7247339_il2cpp_TypeInfo_var)), NULL);
		return;
	}
}
// Method Definition Index: 71951
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void SynchronizationContextCollectionEventDispatcher__cctor_mAE746FE622F984AB183461A080B1C12AD60ABDDE (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Func_1_t8C8AB5C3244441F8D3FD536FF3DC2BB60FD22F87_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Lazy_1__ctor_m6302B6ABC895FA85915F9773675C29AD11C7243C_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Lazy_1_get_Value_mF4F983F782F878359F3120BA280C70276FED6536_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Lazy_1_tFDCCF60E5E7B218CA86C19EE6C5DDE4FEC239292_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&SendOrPostCallback_t5C292A12062F24027A98492F52ECFE9802AA6F0E_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&SynchronizationContextCollectionEventDispatcher_SendOrPostCallback_mD6486EAD82C0B2C3CE78E168A6436A9322C95009_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&SynchronizationContextCollectionEventDispatcher_tD0A54D5AF16049B806210282D1017E5DFF3108A9_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&U3CU3Ec_U3C_cctorU3Eb__7_0_m4068156446C496AA1FF7C88C0705168262FAA44F_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&U3CU3Ec_tD3BCC22757396379C0AF60029CE9F7011891CDB7_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		il2cpp_codegen_runtime_class_init_inline(U3CU3Ec_tD3BCC22757396379C0AF60029CE9F7011891CDB7_il2cpp_TypeInfo_var);
		U3CU3Ec_tD3BCC22757396379C0AF60029CE9F7011891CDB7* L_0 = ((U3CU3Ec_tD3BCC22757396379C0AF60029CE9F7011891CDB7_StaticFields*)il2cpp_codegen_static_fields_for(U3CU3Ec_tD3BCC22757396379C0AF60029CE9F7011891CDB7_il2cpp_TypeInfo_var))->___U3CU3E9;
		Func_1_t8C8AB5C3244441F8D3FD536FF3DC2BB60FD22F87* L_1 = (Func_1_t8C8AB5C3244441F8D3FD536FF3DC2BB60FD22F87*)il2cpp_codegen_object_new(Func_1_t8C8AB5C3244441F8D3FD536FF3DC2BB60FD22F87_il2cpp_TypeInfo_var);
		Func_1__ctor_m8F76037F1B0E7D7A69BE711AFEFF02AB38527CEB(L_1, L_0, (intptr_t)((void*)U3CU3Ec_U3C_cctorU3Eb__7_0_m4068156446C496AA1FF7C88C0705168262FAA44F_RuntimeMethod_var), NULL);
		Lazy_1_tFDCCF60E5E7B218CA86C19EE6C5DDE4FEC239292* L_2 = (Lazy_1_tFDCCF60E5E7B218CA86C19EE6C5DDE4FEC239292*)il2cpp_codegen_object_new(Lazy_1_tFDCCF60E5E7B218CA86C19EE6C5DDE4FEC239292_il2cpp_TypeInfo_var);
		Lazy_1__ctor_m6302B6ABC895FA85915F9773675C29AD11C7243C(L_2, L_1, Lazy_1__ctor_m6302B6ABC895FA85915F9773675C29AD11C7243C_RuntimeMethod_var);
		((SynchronizationContextCollectionEventDispatcher_tD0A54D5AF16049B806210282D1017E5DFF3108A9_StaticFields*)il2cpp_codegen_static_fields_for(SynchronizationContextCollectionEventDispatcher_tD0A54D5AF16049B806210282D1017E5DFF3108A9_il2cpp_TypeInfo_var))->___current = L_2;
		Il2CppCodeGenWriteBarrier((void**)(&((SynchronizationContextCollectionEventDispatcher_tD0A54D5AF16049B806210282D1017E5DFF3108A9_StaticFields*)il2cpp_codegen_static_fields_for(SynchronizationContextCollectionEventDispatcher_tD0A54D5AF16049B806210282D1017E5DFF3108A9_il2cpp_TypeInfo_var))->___current), (void*)L_2);
		Lazy_1_tFDCCF60E5E7B218CA86C19EE6C5DDE4FEC239292* L_3 = ((SynchronizationContextCollectionEventDispatcher_tD0A54D5AF16049B806210282D1017E5DFF3108A9_StaticFields*)il2cpp_codegen_static_fields_for(SynchronizationContextCollectionEventDispatcher_tD0A54D5AF16049B806210282D1017E5DFF3108A9_il2cpp_TypeInfo_var))->___current;
		NullCheck(L_3);
		RuntimeObject* L_4;
		L_4 = Lazy_1_get_Value_mF4F983F782F878359F3120BA280C70276FED6536(L_3, Lazy_1_get_Value_mF4F983F782F878359F3120BA280C70276FED6536_RuntimeMethod_var);
		((SynchronizationContextCollectionEventDispatcher_tD0A54D5AF16049B806210282D1017E5DFF3108A9_StaticFields*)il2cpp_codegen_static_fields_for(SynchronizationContextCollectionEventDispatcher_tD0A54D5AF16049B806210282D1017E5DFF3108A9_il2cpp_TypeInfo_var))->___Current = L_4;
		Il2CppCodeGenWriteBarrier((void**)(&((SynchronizationContextCollectionEventDispatcher_tD0A54D5AF16049B806210282D1017E5DFF3108A9_StaticFields*)il2cpp_codegen_static_fields_for(SynchronizationContextCollectionEventDispatcher_tD0A54D5AF16049B806210282D1017E5DFF3108A9_il2cpp_TypeInfo_var))->___Current), (void*)L_4);
		SendOrPostCallback_t5C292A12062F24027A98492F52ECFE9802AA6F0E* L_5 = (SendOrPostCallback_t5C292A12062F24027A98492F52ECFE9802AA6F0E*)il2cpp_codegen_object_new(SendOrPostCallback_t5C292A12062F24027A98492F52ECFE9802AA6F0E_il2cpp_TypeInfo_var);
		SendOrPostCallback__ctor_mE6F9D9606A00C3C18AEA057422ECF4106C80DA37(L_5, NULL, (intptr_t)((void*)SynchronizationContextCollectionEventDispatcher_SendOrPostCallback_mD6486EAD82C0B2C3CE78E168A6436A9322C95009_RuntimeMethod_var), NULL);
		((SynchronizationContextCollectionEventDispatcher_tD0A54D5AF16049B806210282D1017E5DFF3108A9_StaticFields*)il2cpp_codegen_static_fields_for(SynchronizationContextCollectionEventDispatcher_tD0A54D5AF16049B806210282D1017E5DFF3108A9_il2cpp_TypeInfo_var))->___callback = L_5;
		Il2CppCodeGenWriteBarrier((void**)(&((SynchronizationContextCollectionEventDispatcher_tD0A54D5AF16049B806210282D1017E5DFF3108A9_StaticFields*)il2cpp_codegen_static_fields_for(SynchronizationContextCollectionEventDispatcher_tD0A54D5AF16049B806210282D1017E5DFF3108A9_il2cpp_TypeInfo_var))->___callback), (void*)L_5);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// Method Definition Index: 71952
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void U3CU3Ec__cctor_m9A2EE4315BB495EF82626E73E741B78AB98365F8 (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&U3CU3Ec_tD3BCC22757396379C0AF60029CE9F7011891CDB7_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		U3CU3Ec_tD3BCC22757396379C0AF60029CE9F7011891CDB7* L_0 = (U3CU3Ec_tD3BCC22757396379C0AF60029CE9F7011891CDB7*)il2cpp_codegen_object_new(U3CU3Ec_tD3BCC22757396379C0AF60029CE9F7011891CDB7_il2cpp_TypeInfo_var);
		U3CU3Ec__ctor_mB16A67FB3B05A0BFA173F0B969DA418393672D4C(L_0, NULL);
		((U3CU3Ec_tD3BCC22757396379C0AF60029CE9F7011891CDB7_StaticFields*)il2cpp_codegen_static_fields_for(U3CU3Ec_tD3BCC22757396379C0AF60029CE9F7011891CDB7_il2cpp_TypeInfo_var))->___U3CU3E9 = L_0;
		Il2CppCodeGenWriteBarrier((void**)(&((U3CU3Ec_tD3BCC22757396379C0AF60029CE9F7011891CDB7_StaticFields*)il2cpp_codegen_static_fields_for(U3CU3Ec_tD3BCC22757396379C0AF60029CE9F7011891CDB7_il2cpp_TypeInfo_var))->___U3CU3E9), (void*)L_0);
		return;
	}
}
// Method Definition Index: 71953
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void U3CU3Ec__ctor_mB16A67FB3B05A0BFA173F0B969DA418393672D4C (U3CU3Ec_tD3BCC22757396379C0AF60029CE9F7011891CDB7* __this, const RuntimeMethod* method) 
{
	{
		Object__ctor_mE837C6B9FA8C6D5D109F4B2EC885D79919AC0EA2(__this, NULL);
		return;
	}
}
// Method Definition Index: 71954
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* U3CU3Ec_U3C_cctorU3Eb__7_0_m4068156446C496AA1FF7C88C0705168262FAA44F (U3CU3Ec_tD3BCC22757396379C0AF60029CE9F7011891CDB7* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&SynchronizationContextCollectionEventDispatcher_tD0A54D5AF16049B806210282D1017E5DFF3108A9_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	SynchronizationContext_tCDB842BBE53B050802CBBB59C6E6DC45B5B06DC0* G_B2_0 = NULL;
	SynchronizationContext_tCDB842BBE53B050802CBBB59C6E6DC45B5B06DC0* G_B1_0 = NULL;
	{
		SynchronizationContext_tCDB842BBE53B050802CBBB59C6E6DC45B5B06DC0* L_0;
		L_0 = SynchronizationContext_get_Current_m8DE6D3020745B7955249A2470A23EC0ECBB02A82(NULL);
		SynchronizationContext_tCDB842BBE53B050802CBBB59C6E6DC45B5B06DC0* L_1 = L_0;
		if (L_1)
		{
			G_B2_0 = L_1;
			goto IL_0013;
		}
		G_B1_0 = L_1;
	}
	{
		InvalidOperationException_t5DDE4D49B7405FAAB1E4576F4715A42A3FAD4BAB* L_2 = (InvalidOperationException_t5DDE4D49B7405FAAB1E4576F4715A42A3FAD4BAB*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&InvalidOperationException_t5DDE4D49B7405FAAB1E4576F4715A42A3FAD4BAB_il2cpp_TypeInfo_var)));
		InvalidOperationException__ctor_mE4CB6F4712AB6D99A2358FBAE2E052B3EE976162(L_2, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteral02FF37CC36577E5BBF8EE3F26D829C00193B4DB8)), NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_2, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&U3CU3Ec_U3C_cctorU3Eb__7_0_m4068156446C496AA1FF7C88C0705168262FAA44F_RuntimeMethod_var)));
	}

IL_0013:
	{
		SynchronizationContextCollectionEventDispatcher_tD0A54D5AF16049B806210282D1017E5DFF3108A9* L_3 = (SynchronizationContextCollectionEventDispatcher_tD0A54D5AF16049B806210282D1017E5DFF3108A9*)il2cpp_codegen_object_new(SynchronizationContextCollectionEventDispatcher_tD0A54D5AF16049B806210282D1017E5DFF3108A9_il2cpp_TypeInfo_var);
		SynchronizationContextCollectionEventDispatcher__ctor_m77B04E33F10CCD9B01631CAA62A1296E883DC831(L_3, G_B2_0, NULL);
		return L_3;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// Method Definition Index: 71955
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void InlineCollectionEventDispatcher__ctor_m91C50DF243DD89CDAA915C9CBAD933A9461ED64A (InlineCollectionEventDispatcher_t6C5003C831CE0A044CB873B6A3058B992900D761* __this, const RuntimeMethod* method) 
{
	{
		Object__ctor_mE837C6B9FA8C6D5D109F4B2EC885D79919AC0EA2(__this, NULL);
		return;
	}
}
// Method Definition Index: 71956
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void InlineCollectionEventDispatcher_Post_m4697DF5A2A31D5F3107FCBD655CDE83B17B9BB9A (InlineCollectionEventDispatcher_t6C5003C831CE0A044CB873B6A3058B992900D761* __this, CollectionEventDispatcherEventArgs_t897929345863379302C0A2FDAF37F55BA7247339* ___0_ev, const RuntimeMethod* method) 
{
	{
		CollectionEventDispatcherEventArgs_t897929345863379302C0A2FDAF37F55BA7247339* L_0 = ___0_ev;
		NullCheck(L_0);
		CollectionEventDispatcherEventArgs_Invoke_mA3D48E82E2A707789B0BD50199E828D8B623D343(L_0, NULL);
		return;
	}
}
// Method Definition Index: 71957
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void InlineCollectionEventDispatcher__cctor_m1F480FF5688251E3DF11FE9B6588E4070469CDD6 (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&InlineCollectionEventDispatcher_t6C5003C831CE0A044CB873B6A3058B992900D761_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		InlineCollectionEventDispatcher_t6C5003C831CE0A044CB873B6A3058B992900D761* L_0 = (InlineCollectionEventDispatcher_t6C5003C831CE0A044CB873B6A3058B992900D761*)il2cpp_codegen_object_new(InlineCollectionEventDispatcher_t6C5003C831CE0A044CB873B6A3058B992900D761_il2cpp_TypeInfo_var);
		InlineCollectionEventDispatcher__ctor_m91C50DF243DD89CDAA915C9CBAD933A9461ED64A(L_0, NULL);
		((InlineCollectionEventDispatcher_t6C5003C831CE0A044CB873B6A3058B992900D761_StaticFields*)il2cpp_codegen_static_fields_for(InlineCollectionEventDispatcher_t6C5003C831CE0A044CB873B6A3058B992900D761_il2cpp_TypeInfo_var))->___Instance = L_0;
		Il2CppCodeGenWriteBarrier((void**)(&((InlineCollectionEventDispatcher_t6C5003C831CE0A044CB873B6A3058B992900D761_StaticFields*)il2cpp_codegen_static_fields_for(InlineCollectionEventDispatcher_t6C5003C831CE0A044CB873B6A3058B992900D761_il2cpp_TypeInfo_var))->___Instance), (void*)L_0);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// Method Definition Index: 71958
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* CollectionEventDispatcherEventArgs_get_Collection_mA001197CFA9930B0831808B3A6C457C0791C5DC9 (CollectionEventDispatcherEventArgs_t897929345863379302C0A2FDAF37F55BA7247339* __this, const RuntimeMethod* method) 
{
	{
		RuntimeObject* L_0 = __this->___U3CCollectionU3Ek__BackingField;
		return L_0;
	}
}
// Method Definition Index: 71959
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void CollectionEventDispatcherEventArgs_set_Collection_m192938ABBA36536C06A33D77BD6F15E331617148 (CollectionEventDispatcherEventArgs_t897929345863379302C0A2FDAF37F55BA7247339* __this, RuntimeObject* ___0_value, const RuntimeMethod* method) 
{
	{
		RuntimeObject* L_0 = ___0_value;
		__this->___U3CCollectionU3Ek__BackingField = L_0;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___U3CCollectionU3Ek__BackingField), (void*)L_0);
		return;
	}
}
// Method Definition Index: 71960
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool CollectionEventDispatcherEventArgs_get_IsInvokeCollectionChanged_m2525C488634F9725852AC78B3B2A4F9CEEF61127 (CollectionEventDispatcherEventArgs_t897929345863379302C0A2FDAF37F55BA7247339* __this, const RuntimeMethod* method) 
{
	{
		bool L_0 = __this->___U3CIsInvokeCollectionChangedU3Ek__BackingField;
		return L_0;
	}
}
// Method Definition Index: 71961
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void CollectionEventDispatcherEventArgs_set_IsInvokeCollectionChanged_m6846CFC03292F3A81D3CD25567634CF38D2E697B (CollectionEventDispatcherEventArgs_t897929345863379302C0A2FDAF37F55BA7247339* __this, bool ___0_value, const RuntimeMethod* method) 
{
	{
		bool L_0 = ___0_value;
		__this->___U3CIsInvokeCollectionChangedU3Ek__BackingField = L_0;
		return;
	}
}
// Method Definition Index: 71962
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool CollectionEventDispatcherEventArgs_get_IsInvokePropertyChanged_m165C322DEC621F3000A18D2257414640407FD512 (CollectionEventDispatcherEventArgs_t897929345863379302C0A2FDAF37F55BA7247339* __this, const RuntimeMethod* method) 
{
	{
		bool L_0 = __this->___U3CIsInvokePropertyChangedU3Ek__BackingField;
		return L_0;
	}
}
// Method Definition Index: 71963
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void CollectionEventDispatcherEventArgs_set_IsInvokePropertyChanged_mB3202BFABAB32FFCFC913B7D62F4EFAD28ED8E94 (CollectionEventDispatcherEventArgs_t897929345863379302C0A2FDAF37F55BA7247339* __this, bool ___0_value, const RuntimeMethod* method) 
{
	{
		bool L_0 = ___0_value;
		__this->___U3CIsInvokePropertyChangedU3Ek__BackingField = L_0;
		return;
	}
}
// Method Definition Index: 71964
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Action_1_t4886BB533893363037886031AFA3134F2BE506A0* CollectionEventDispatcherEventArgs_get_Invoker_m85B5EDE12797490123B2F37090EC1DAF5898D33D (CollectionEventDispatcherEventArgs_t897929345863379302C0A2FDAF37F55BA7247339* __this, const RuntimeMethod* method) 
{
	{
		Action_1_t4886BB533893363037886031AFA3134F2BE506A0* L_0 = __this->___U3CInvokerU3Ek__BackingField;
		return L_0;
	}
}
// Method Definition Index: 71965
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void CollectionEventDispatcherEventArgs_set_Invoker_m91CF17EE630479BEE6D6CCE9FD9F6C102A76842C (CollectionEventDispatcherEventArgs_t897929345863379302C0A2FDAF37F55BA7247339* __this, Action_1_t4886BB533893363037886031AFA3134F2BE506A0* ___0_value, const RuntimeMethod* method) 
{
	{
		Action_1_t4886BB533893363037886031AFA3134F2BE506A0* L_0 = ___0_value;
		__this->___U3CInvokerU3Ek__BackingField = L_0;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___U3CInvokerU3Ek__BackingField), (void*)L_0);
		return;
	}
}
// Method Definition Index: 71966
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void CollectionEventDispatcherEventArgs_Invoke_mA3D48E82E2A707789B0BD50199E828D8B623D343 (CollectionEventDispatcherEventArgs_t897929345863379302C0A2FDAF37F55BA7247339* __this, const RuntimeMethod* method) 
{
	{
		Action_1_t4886BB533893363037886031AFA3134F2BE506A0* L_0;
		L_0 = CollectionEventDispatcherEventArgs_get_Invoker_m85B5EDE12797490123B2F37090EC1DAF5898D33D_inline(__this, NULL);
		NullCheck(L_0);
		Action_1_Invoke_m958803F460E839AA5E59C3FEA4D23188B1B22365_inline(L_0, __this, NULL);
		return;
	}
}
// Method Definition Index: 71967
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void CollectionEventDispatcherEventArgs__ctor_m7A62390E3CF168931BEB2D20E966F79C3AB88658 (CollectionEventDispatcherEventArgs_t897929345863379302C0A2FDAF37F55BA7247339* __this, int32_t ___0_action, const RuntimeMethod* method) 
{
	{
		int32_t L_0 = ___0_action;
		NotifyCollectionChangedEventArgs__ctor_m1EE75703595F07CE93EFC0861AAE02EE9B3AC823(__this, L_0, NULL);
		return;
	}
}
// Method Definition Index: 71968
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void CollectionEventDispatcherEventArgs__ctor_m8341A2642C640B3F6421240AFE146F657A85067E (CollectionEventDispatcherEventArgs_t897929345863379302C0A2FDAF37F55BA7247339* __this, int32_t ___0_action, RuntimeObject* ___1_changedItems, const RuntimeMethod* method) 
{
	{
		int32_t L_0 = ___0_action;
		RuntimeObject* L_1 = ___1_changedItems;
		NotifyCollectionChangedEventArgs__ctor_m94EF19F0CEA17A580708E067B4553B8683DE70DE(__this, L_0, L_1, NULL);
		return;
	}
}
// Method Definition Index: 71969
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void CollectionEventDispatcherEventArgs__ctor_mEE95686276EFD7BCD39F6C953C6EAF8B7C9190E8 (CollectionEventDispatcherEventArgs_t897929345863379302C0A2FDAF37F55BA7247339* __this, int32_t ___0_action, RuntimeObject* ___1_changedItem, const RuntimeMethod* method) 
{
	{
		int32_t L_0 = ___0_action;
		RuntimeObject* L_1 = ___1_changedItem;
		NotifyCollectionChangedEventArgs__ctor_mA0FDC21EB566901D817C29A859B930FF28968158(__this, L_0, L_1, NULL);
		return;
	}
}
// Method Definition Index: 71970
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void CollectionEventDispatcherEventArgs__ctor_mC993CC6BDE36573F8B0F83557CB28E2D61FAB35D (CollectionEventDispatcherEventArgs_t897929345863379302C0A2FDAF37F55BA7247339* __this, int32_t ___0_action, RuntimeObject* ___1_newItems, RuntimeObject* ___2_oldItems, const RuntimeMethod* method) 
{
	{
		int32_t L_0 = ___0_action;
		RuntimeObject* L_1 = ___1_newItems;
		RuntimeObject* L_2 = ___2_oldItems;
		NotifyCollectionChangedEventArgs__ctor_mBFD6D3F3F7E50F8D7E6B6C005DC983BD8F4FEB0D(__this, L_0, L_1, L_2, NULL);
		return;
	}
}
// Method Definition Index: 71971
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void CollectionEventDispatcherEventArgs__ctor_m3130148753AAFF6B972772C881CB31C239BF1591 (CollectionEventDispatcherEventArgs_t897929345863379302C0A2FDAF37F55BA7247339* __this, int32_t ___0_action, RuntimeObject* ___1_changedItems, int32_t ___2_startingIndex, const RuntimeMethod* method) 
{
	{
		int32_t L_0 = ___0_action;
		RuntimeObject* L_1 = ___1_changedItems;
		int32_t L_2 = ___2_startingIndex;
		NotifyCollectionChangedEventArgs__ctor_m8D4BE63EF4D5570DDA84FE7449C12358CE22FC9F(__this, L_0, L_1, L_2, NULL);
		return;
	}
}
// Method Definition Index: 71972
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void CollectionEventDispatcherEventArgs__ctor_m7B07A5F91E2CCE4BC686E09648C2F113623E30D8 (CollectionEventDispatcherEventArgs_t897929345863379302C0A2FDAF37F55BA7247339* __this, int32_t ___0_action, RuntimeObject* ___1_changedItem, int32_t ___2_index, const RuntimeMethod* method) 
{
	{
		int32_t L_0 = ___0_action;
		RuntimeObject* L_1 = ___1_changedItem;
		int32_t L_2 = ___2_index;
		NotifyCollectionChangedEventArgs__ctor_m010974C04F22D47110DCD77005CA026F7EA2F7B7(__this, L_0, L_1, L_2, NULL);
		return;
	}
}
// Method Definition Index: 71973
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void CollectionEventDispatcherEventArgs__ctor_m585A1B6438B9EEDB14DDCE7C19E40429242FFF63 (CollectionEventDispatcherEventArgs_t897929345863379302C0A2FDAF37F55BA7247339* __this, int32_t ___0_action, RuntimeObject* ___1_newItem, RuntimeObject* ___2_oldItem, const RuntimeMethod* method) 
{
	{
		int32_t L_0 = ___0_action;
		RuntimeObject* L_1 = ___1_newItem;
		RuntimeObject* L_2 = ___2_oldItem;
		NotifyCollectionChangedEventArgs__ctor_m3BF1219EE3A15FCF07D54BD727F74EAB6D0EC785(__this, L_0, L_1, L_2, NULL);
		return;
	}
}
// Method Definition Index: 71974
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void CollectionEventDispatcherEventArgs__ctor_m717A0BE5548737B345164E2814026B9C7F14874A (CollectionEventDispatcherEventArgs_t897929345863379302C0A2FDAF37F55BA7247339* __this, int32_t ___0_action, RuntimeObject* ___1_newItems, RuntimeObject* ___2_oldItems, int32_t ___3_startingIndex, const RuntimeMethod* method) 
{
	{
		int32_t L_0 = ___0_action;
		RuntimeObject* L_1 = ___1_newItems;
		RuntimeObject* L_2 = ___2_oldItems;
		int32_t L_3 = ___3_startingIndex;
		NotifyCollectionChangedEventArgs__ctor_m58DB02BBDF35CCB817A0635AEBA6592C8167F49C(__this, L_0, L_1, L_2, L_3, NULL);
		return;
	}
}
// Method Definition Index: 71975
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void CollectionEventDispatcherEventArgs__ctor_mFDA598D40F6F6586D05BF09E1CC01CA2EC0F9C74 (CollectionEventDispatcherEventArgs_t897929345863379302C0A2FDAF37F55BA7247339* __this, int32_t ___0_action, RuntimeObject* ___1_changedItems, int32_t ___2_index, int32_t ___3_oldIndex, const RuntimeMethod* method) 
{
	{
		int32_t L_0 = ___0_action;
		RuntimeObject* L_1 = ___1_changedItems;
		int32_t L_2 = ___2_index;
		int32_t L_3 = ___3_oldIndex;
		NotifyCollectionChangedEventArgs__ctor_m5D106E40619F1A2C1804767917CCA4885EF02D3E(__this, L_0, L_1, L_2, L_3, NULL);
		return;
	}
}
// Method Definition Index: 71976
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void CollectionEventDispatcherEventArgs__ctor_mE4F5AE5F32D4C5DA314898AD4867CE76E6D04A7F (CollectionEventDispatcherEventArgs_t897929345863379302C0A2FDAF37F55BA7247339* __this, int32_t ___0_action, RuntimeObject* ___1_changedItem, int32_t ___2_index, int32_t ___3_oldIndex, const RuntimeMethod* method) 
{
	{
		int32_t L_0 = ___0_action;
		RuntimeObject* L_1 = ___1_changedItem;
		int32_t L_2 = ___2_index;
		int32_t L_3 = ___3_oldIndex;
		NotifyCollectionChangedEventArgs__ctor_m4C36BCE7D7E31A5A659E5770024C202216EB36AE(__this, L_0, L_1, L_2, L_3, NULL);
		return;
	}
}
// Method Definition Index: 71977
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void CollectionEventDispatcherEventArgs__ctor_mF088D6BF87B9C715EB0ECA4F340F7289854F7087 (CollectionEventDispatcherEventArgs_t897929345863379302C0A2FDAF37F55BA7247339* __this, int32_t ___0_action, RuntimeObject* ___1_newItem, RuntimeObject* ___2_oldItem, int32_t ___3_index, const RuntimeMethod* method) 
{
	{
		int32_t L_0 = ___0_action;
		RuntimeObject* L_1 = ___1_newItem;
		RuntimeObject* L_2 = ___2_oldItem;
		int32_t L_3 = ___3_index;
		NotifyCollectionChangedEventArgs__ctor_m839DE4731C24001AE7820BFE9F7B56DC05CE1CD3(__this, L_0, L_1, L_2, L_3, NULL);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
IL2CPP_EXTERN_C void FixedBoolArray_tC32093C6C050FB8FAA864BD206C0A2C3F5A9003A_marshal_pinvoke(const FixedBoolArray_tC32093C6C050FB8FAA864BD206C0A2C3F5A9003A& unmarshaled, FixedBoolArray_tC32093C6C050FB8FAA864BD206C0A2C3F5A9003A_marshaled_pinvoke& marshaled)
{
	marshaled.___Span = unmarshaled.___Span;
	if (unmarshaled.___array != NULL)
	{
		il2cpp_array_size_t _unmarshaledarray_Length = (unmarshaled.___array)->max_length;
		marshaled.___array = il2cpp_codegen_marshal_allocate_array<int32_t>(_unmarshaledarray_Length);
		for (int32_t i = 0; i < ARRAY_LENGTH_AS_INT32(_unmarshaledarray_Length); i++)
		{
			(marshaled.___array)[i] = static_cast<int32_t>((unmarshaled.___array)->GetAtUnchecked(static_cast<il2cpp_array_size_t>(i)));
		}
	}
	else
	{
		marshaled.___array = NULL;
	}
}
IL2CPP_EXTERN_C void FixedBoolArray_tC32093C6C050FB8FAA864BD206C0A2C3F5A9003A_marshal_pinvoke_back(const FixedBoolArray_tC32093C6C050FB8FAA864BD206C0A2C3F5A9003A_marshaled_pinvoke& marshaled, FixedBoolArray_tC32093C6C050FB8FAA864BD206C0A2C3F5A9003A& unmarshaled)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&BooleanU5BU5D_tD317D27C31DB892BE79FAE3AEBC0B3FFB73DE9B4_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Span_1_t087F0E3724EBFD3A74A84E3F9E3F027249F37B51 unmarshaledSpan_temp_0;
	memset((&unmarshaledSpan_temp_0), 0, sizeof(unmarshaledSpan_temp_0));
	unmarshaledSpan_temp_0 = marshaled.___Span;
	unmarshaled.___Span = unmarshaledSpan_temp_0;
	if (marshaled.___array != NULL)
	{
		if (unmarshaled.___array == NULL)
		{
			unmarshaled.___array = reinterpret_cast<BooleanU5BU5D_tD317D27C31DB892BE79FAE3AEBC0B3FFB73DE9B4*>((BooleanU5BU5D_tD317D27C31DB892BE79FAE3AEBC0B3FFB73DE9B4*)SZArrayNew(BooleanU5BU5D_tD317D27C31DB892BE79FAE3AEBC0B3FFB73DE9B4_il2cpp_TypeInfo_var, 1));
		}
		il2cpp_array_size_t _arrayLength = (unmarshaled.___array)->max_length;
		for (int32_t i = 0; i < ARRAY_LENGTH_AS_INT32(_arrayLength); i++)
		{
			(unmarshaled.___array)->SetAtUnchecked(static_cast<il2cpp_array_size_t>(i), static_cast<bool>((marshaled.___array)[i]));
		}
	}
}
IL2CPP_EXTERN_C void FixedBoolArray_tC32093C6C050FB8FAA864BD206C0A2C3F5A9003A_marshal_pinvoke_cleanup(FixedBoolArray_tC32093C6C050FB8FAA864BD206C0A2C3F5A9003A_marshaled_pinvoke& marshaled)
{
	if (marshaled.___array != NULL)
	{
		il2cpp_codegen_marshal_free(marshaled.___array);
		marshaled.___array = NULL;
	}
}
IL2CPP_EXTERN_C void FixedBoolArray_tC32093C6C050FB8FAA864BD206C0A2C3F5A9003A_marshal_com(const FixedBoolArray_tC32093C6C050FB8FAA864BD206C0A2C3F5A9003A& unmarshaled, FixedBoolArray_tC32093C6C050FB8FAA864BD206C0A2C3F5A9003A_marshaled_com& marshaled)
{
	marshaled.___Span = unmarshaled.___Span;
	if (unmarshaled.___array != NULL)
	{
		il2cpp_array_size_t _unmarshaledarray_Length = (unmarshaled.___array)->max_length;
		marshaled.___array = il2cpp_codegen_marshal_allocate_array<int32_t>(_unmarshaledarray_Length);
		for (int32_t i = 0; i < ARRAY_LENGTH_AS_INT32(_unmarshaledarray_Length); i++)
		{
			(marshaled.___array)[i] = static_cast<int32_t>((unmarshaled.___array)->GetAtUnchecked(static_cast<il2cpp_array_size_t>(i)));
		}
	}
	else
	{
		marshaled.___array = NULL;
	}
}
IL2CPP_EXTERN_C void FixedBoolArray_tC32093C6C050FB8FAA864BD206C0A2C3F5A9003A_marshal_com_back(const FixedBoolArray_tC32093C6C050FB8FAA864BD206C0A2C3F5A9003A_marshaled_com& marshaled, FixedBoolArray_tC32093C6C050FB8FAA864BD206C0A2C3F5A9003A& unmarshaled)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&BooleanU5BU5D_tD317D27C31DB892BE79FAE3AEBC0B3FFB73DE9B4_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Span_1_t087F0E3724EBFD3A74A84E3F9E3F027249F37B51 unmarshaledSpan_temp_0;
	memset((&unmarshaledSpan_temp_0), 0, sizeof(unmarshaledSpan_temp_0));
	unmarshaledSpan_temp_0 = marshaled.___Span;
	unmarshaled.___Span = unmarshaledSpan_temp_0;
	if (marshaled.___array != NULL)
	{
		if (unmarshaled.___array == NULL)
		{
			unmarshaled.___array = reinterpret_cast<BooleanU5BU5D_tD317D27C31DB892BE79FAE3AEBC0B3FFB73DE9B4*>((BooleanU5BU5D_tD317D27C31DB892BE79FAE3AEBC0B3FFB73DE9B4*)SZArrayNew(BooleanU5BU5D_tD317D27C31DB892BE79FAE3AEBC0B3FFB73DE9B4_il2cpp_TypeInfo_var, 1));
		}
		il2cpp_array_size_t _arrayLength = (unmarshaled.___array)->max_length;
		for (int32_t i = 0; i < ARRAY_LENGTH_AS_INT32(_arrayLength); i++)
		{
			(unmarshaled.___array)->SetAtUnchecked(static_cast<il2cpp_array_size_t>(i), static_cast<bool>((marshaled.___array)[i]));
		}
	}
}
IL2CPP_EXTERN_C void FixedBoolArray_tC32093C6C050FB8FAA864BD206C0A2C3F5A9003A_marshal_com_cleanup(FixedBoolArray_tC32093C6C050FB8FAA864BD206C0A2C3F5A9003A_marshaled_com& marshaled)
{
	if (marshaled.___array != NULL)
	{
		il2cpp_codegen_marshal_free(marshaled.___array);
		marshaled.___array = NULL;
	}
}
// Method Definition Index: 72903
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void FixedBoolArray__ctor_mC5AF8383135198341DBB87253720B08FF6C072C3 (FixedBoolArray_tC32093C6C050FB8FAA864BD206C0A2C3F5A9003A* __this, Span_1_t087F0E3724EBFD3A74A84E3F9E3F027249F37B51 ___0_scratchBuffer, int32_t ___1_capacity, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ArrayPool_1_get_Shared_m4880204C02055CC88D825651B2940134A9F99C35_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ArrayPool_1_tA078350A0D495C7FFCFF5BF612FA605A894B24F7_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MemoryExtensions_AsSpan_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_m4B450C631366925983E48616CE396F35E694835D_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Span_1_get_Length_mED1253429B93CB6D2928015A22105A16FF64C86B_RuntimeMethod_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		__this->___array = (BooleanU5BU5D_tD317D27C31DB892BE79FAE3AEBC0B3FFB73DE9B4*)NULL;
		int32_t L_0;
		L_0 = Span_1_get_Length_mED1253429B93CB6D2928015A22105A16FF64C86B_inline((&___0_scratchBuffer), Span_1_get_Length_mED1253429B93CB6D2928015A22105A16FF64C86B_RuntimeMethod_var);
		if (L_0)
		{
			goto IL_0035;
		}
	}
	{
		il2cpp_codegen_runtime_class_init_inline(ArrayPool_1_tA078350A0D495C7FFCFF5BF612FA605A894B24F7_il2cpp_TypeInfo_var);
		ArrayPool_1_tA078350A0D495C7FFCFF5BF612FA605A894B24F7* L_1;
		L_1 = ArrayPool_1_get_Shared_m4880204C02055CC88D825651B2940134A9F99C35_inline(ArrayPool_1_get_Shared_m4880204C02055CC88D825651B2940134A9F99C35_RuntimeMethod_var);
		int32_t L_2 = ___1_capacity;
		NullCheck(L_1);
		BooleanU5BU5D_tD317D27C31DB892BE79FAE3AEBC0B3FFB73DE9B4* L_3;
		L_3 = VirtualFuncInvoker1< BooleanU5BU5D_tD317D27C31DB892BE79FAE3AEBC0B3FFB73DE9B4*, int32_t >::Invoke(4, L_1, L_2);
		__this->___array = L_3;
		BooleanU5BU5D_tD317D27C31DB892BE79FAE3AEBC0B3FFB73DE9B4* L_4 = __this->___array;
		int32_t L_5 = ___1_capacity;
		Span_1_t087F0E3724EBFD3A74A84E3F9E3F027249F37B51 L_6;
		L_6 = MemoryExtensions_AsSpan_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_m4B450C631366925983E48616CE396F35E694835D_inline(L_4, 0, L_5, MemoryExtensions_AsSpan_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_m4B450C631366925983E48616CE396F35E694835D_RuntimeMethod_var);
		__this->___Span = L_6;
		return;
	}

IL_0035:
	{
		Span_1_t087F0E3724EBFD3A74A84E3F9E3F027249F37B51 L_7 = ___0_scratchBuffer;
		__this->___Span = L_7;
		return;
	}
}
// Method Definition Index: 72904
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void FixedBoolArray_Dispose_m5F836AAE6A8CCB979F141A950521558B7ADD6140 (FixedBoolArray_tC32093C6C050FB8FAA864BD206C0A2C3F5A9003A* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ArrayPool_1_get_Shared_m4880204C02055CC88D825651B2940134A9F99C35_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ArrayPool_1_tA078350A0D495C7FFCFF5BF612FA605A894B24F7_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		BooleanU5BU5D_tD317D27C31DB892BE79FAE3AEBC0B3FFB73DE9B4* L_0 = __this->___array;
		if (!L_0)
		{
			goto IL_0019;
		}
	}
	{
		il2cpp_codegen_runtime_class_init_inline(ArrayPool_1_tA078350A0D495C7FFCFF5BF612FA605A894B24F7_il2cpp_TypeInfo_var);
		ArrayPool_1_tA078350A0D495C7FFCFF5BF612FA605A894B24F7* L_1;
		L_1 = ArrayPool_1_get_Shared_m4880204C02055CC88D825651B2940134A9F99C35_inline(ArrayPool_1_get_Shared_m4880204C02055CC88D825651B2940134A9F99C35_RuntimeMethod_var);
		BooleanU5BU5D_tD317D27C31DB892BE79FAE3AEBC0B3FFB73DE9B4* L_2 = __this->___array;
		NullCheck(L_1);
		VirtualActionInvoker2< BooleanU5BU5D_tD317D27C31DB892BE79FAE3AEBC0B3FFB73DE9B4*, bool >::Invoke(5, L_1, L_2, (bool)0);
	}

IL_0019:
	{
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
// Method Definition Index: 3775
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void SendOrPostCallback_Invoke_m23B949AF9D78E8635F84E1E7775A50472B4F9C28_inline (SendOrPostCallback_t5C292A12062F24027A98492F52ECFE9802AA6F0E* __this, RuntimeObject* ___0_state, const RuntimeMethod* method) 
{
	typedef void (*FunctionPointerType) (RuntimeObject*, RuntimeObject*, const RuntimeMethod*);
	((FunctionPointerType)__this->___invoke_impl)((Il2CppObject*)__this->___method_code, ___0_state, reinterpret_cast<RuntimeMethod*>(__this->___method));
}
// Method Definition Index: 71964
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Action_1_t4886BB533893363037886031AFA3134F2BE506A0* CollectionEventDispatcherEventArgs_get_Invoker_m85B5EDE12797490123B2F37090EC1DAF5898D33D_inline (CollectionEventDispatcherEventArgs_t897929345863379302C0A2FDAF37F55BA7247339* __this, const RuntimeMethod* method) 
{
	{
		Action_1_t4886BB533893363037886031AFA3134F2BE506A0* L_0 = __this->___U3CInvokerU3Ek__BackingField;
		return L_0;
	}
}
// Method Definition Index: 602
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Action_1_Invoke_mF2422B2DD29F74CE66F791C3F68E288EC7C3DB9E_gshared_inline (Action_1_t6F9EB113EB3F16226AEF811A2744F4111C116C87* __this, RuntimeObject* ___0_obj, const RuntimeMethod* method) 
{
	typedef void (*FunctionPointerType) (RuntimeObject*, RuntimeObject*, const RuntimeMethod*);
	((FunctionPointerType)__this->___invoke_impl)((Il2CppObject*)__this->___method_code, ___0_obj, reinterpret_cast<RuntimeMethod*>(__this->___method));
}
// Method Definition Index: 2046
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t Span_1_get_Length_mED1253429B93CB6D2928015A22105A16FF64C86B_gshared_inline (Span_1_t087F0E3724EBFD3A74A84E3F9E3F027249F37B51* __this, const RuntimeMethod* method) 
{
	{
		int32_t L_0 = __this->____length;
		return L_0;
	}
}
// Method Definition Index: 9715
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR ArrayPool_1_tA078350A0D495C7FFCFF5BF612FA605A894B24F7* ArrayPool_1_get_Shared_m4880204C02055CC88D825651B2940134A9F99C35_gshared_inline (const RuntimeMethod* method) 
{
	{
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		ArrayPool_1_tA078350A0D495C7FFCFF5BF612FA605A894B24F7* L_0 = ((ArrayPool_1_tA078350A0D495C7FFCFF5BF612FA605A894B24F7_StaticFields*)il2cpp_codegen_static_fields_for(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1)))->___U3CSharedU3Ek__BackingField;
		return L_0;
	}
}
// Method Definition Index: 1735
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Span_1_t087F0E3724EBFD3A74A84E3F9E3F027249F37B51 MemoryExtensions_AsSpan_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_m4B450C631366925983E48616CE396F35E694835D_gshared_inline (BooleanU5BU5D_tD317D27C31DB892BE79FAE3AEBC0B3FFB73DE9B4* ___0_array, int32_t ___1_start, int32_t ___2_length, const RuntimeMethod* method) 
{
	il2cpp_rgctx_method_init(method);
	{
		BooleanU5BU5D_tD317D27C31DB892BE79FAE3AEBC0B3FFB73DE9B4* L_0 = ___0_array;
		int32_t L_1 = ___1_start;
		int32_t L_2 = ___2_length;
		Span_1_t087F0E3724EBFD3A74A84E3F9E3F027249F37B51 L_3;
		memset((&L_3), 0, sizeof(L_3));
		Span_1__ctor_mF010B57B13C6597DA14D7957BD2E07090F8336A6_inline((&L_3), L_0, L_1, L_2, il2cpp_rgctx_method(method->rgctx_data, 2));
		return L_3;
	}
}
// Method Definition Index: 2032
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Span_1__ctor_mF010B57B13C6597DA14D7957BD2E07090F8336A6_gshared_inline (Span_1_t087F0E3724EBFD3A74A84E3F9E3F027249F37B51* __this, BooleanU5BU5D_tD317D27C31DB892BE79FAE3AEBC0B3FFB73DE9B4* ___0_array, int32_t ___1_start, int32_t ___2_length, const RuntimeMethod* method) 
{
	bool V_0 = false;
	{
		BooleanU5BU5D_tD317D27C31DB892BE79FAE3AEBC0B3FFB73DE9B4* L_0 = ___0_array;
		if (L_0)
		{
			goto IL_0016;
		}
	}
	{
		int32_t L_1 = ___1_start;
		if (L_1)
		{
			goto IL_0009;
		}
	}
	{
		int32_t L_2 = ___2_length;
		if (!L_2)
		{
			goto IL_000e;
		}
	}

IL_0009:
	{
		ThrowHelper_ThrowArgumentOutOfRangeException_mD7D90276EDCDF9394A8EA635923E3B48BB71BD56(NULL);
	}

IL_000e:
	{
		il2cpp_codegen_initobj(__this, sizeof(Span_1_t087F0E3724EBFD3A74A84E3F9E3F027249F37B51));
		return;
	}

IL_0016:
	{
		il2cpp_codegen_initobj((&V_0), sizeof(bool));
		goto IL_0042;
	}

IL_0042:
	{
		int32_t L_4 = ___1_start;
		BooleanU5BU5D_tD317D27C31DB892BE79FAE3AEBC0B3FFB73DE9B4* L_5 = ___0_array;
		NullCheck(L_5);
		if ((!(((uint32_t)L_4) <= ((uint32_t)((int32_t)(((RuntimeArray*)L_5)->max_length))))))
		{
			goto IL_0050;
		}
	}
	{
		int32_t L_6 = ___2_length;
		BooleanU5BU5D_tD317D27C31DB892BE79FAE3AEBC0B3FFB73DE9B4* L_7 = ___0_array;
		NullCheck(L_7);
		int32_t L_8 = ___1_start;
		if ((!(((uint32_t)L_6) > ((uint32_t)((int32_t)il2cpp_codegen_subtract(((int32_t)(((RuntimeArray*)L_7)->max_length)), L_8))))))
		{
			goto IL_0055;
		}
	}

IL_0050:
	{
		ThrowHelper_ThrowArgumentOutOfRangeException_mD7D90276EDCDF9394A8EA635923E3B48BB71BD56(NULL);
	}

IL_0055:
	{
		BooleanU5BU5D_tD317D27C31DB892BE79FAE3AEBC0B3FFB73DE9B4* L_9 = ___0_array;
		NullCheck((RuntimeArray*)L_9);
		uint8_t* L_10;
		L_10 = Array_GetRawSzArrayData_m2F8F5B2A381AEF971F12866D9C0A6C4FBA59F6BB_inline((RuntimeArray*)L_9, NULL);
		bool* L_11;
		L_11 = il2cpp_unsafe_as_ref<bool>(L_10);
		int32_t L_12 = ___1_start;
		bool* L_13;
		L_13 = il2cpp_unsafe_add<bool,int32_t>(L_11, L_12);
		ByReference_1_t98C4399D749F9F8F828547057023CF78951E6126 L_14;
		memset((&L_14), 0, sizeof(L_14));
		il2cpp_codegen_by_reference_constructor((Il2CppByReference*)(&L_14), L_13);
		__this->____pointer = L_14;
		int32_t L_15 = ___2_length;
		__this->____length = L_15;
		return;
	}
}
// Method Definition Index: 2722
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR uint8_t* Array_GetRawSzArrayData_m2F8F5B2A381AEF971F12866D9C0A6C4FBA59F6BB_inline (RuntimeArray* __this, const RuntimeMethod* method) 
{
	{
		RawData_t37CAF2D3F74B7723974ED7CEEE9B297D8FA64ED0* L_0;
		L_0 = il2cpp_unsafe_as<RawData_t37CAF2D3F74B7723974ED7CEEE9B297D8FA64ED0*>(__this);
		NullCheck(L_0);
		uint8_t* L_1 = (uint8_t*)(&L_0->___Data);
		return L_1;
	}
}
