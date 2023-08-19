#include "pch-cpp.hpp"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif


#include <limits>
#include <stdint.h>



// System.Attribute
struct Attribute_tFDA8EFEFB0711976D22474794576DAF28F7440AA;
// EasyButtons.ButtonAttribute
struct ButtonAttribute_tC1B0F9DFC9D8073AEB558454AD8FE9E18EEC9394;
// System.String
struct String_t;



IL2CPP_EXTERN_C_BEGIN
IL2CPP_EXTERN_C_END

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// <Module>
struct U3CModuleU3E_tB113BC7C970E8EC0C97D2EF13B975CD09EE0E155 
{
};
struct Il2CppArrayBounds;

// System.Attribute
struct Attribute_tFDA8EFEFB0711976D22474794576DAF28F7440AA  : public RuntimeObject
{
};

// System.String
struct String_t  : public RuntimeObject
{
	// System.Int32 System.String::_stringLength
	int32_t ____stringLength_4;
	// System.Char System.String::_firstChar
	Il2CppChar ____firstChar_5;
};

struct String_t_StaticFields
{
	// System.String System.String::Empty
	String_t* ___Empty_6;
};

// System.ValueType
struct ValueType_t6D9B272BD21782F0A9A14F2E41F85A50E97A986F  : public RuntimeObject
{
};
// Native definition for P/Invoke marshalling of System.ValueType
struct ValueType_t6D9B272BD21782F0A9A14F2E41F85A50E97A986F_marshaled_pinvoke
{
};
// Native definition for COM marshalling of System.ValueType
struct ValueType_t6D9B272BD21782F0A9A14F2E41F85A50E97A986F_marshaled_com
{
};

// System.Boolean
struct Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22 
{
	// System.Boolean System.Boolean::m_value
	bool ___m_value_0;
};

struct Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_StaticFields
{
	// System.String System.Boolean::TrueString
	String_t* ___TrueString_5;
	// System.String System.Boolean::FalseString
	String_t* ___FalseString_6;
};

// EasyButtons.ButtonAttribute
struct ButtonAttribute_tC1B0F9DFC9D8073AEB558454AD8FE9E18EEC9394  : public Attribute_tFDA8EFEFB0711976D22474794576DAF28F7440AA
{
	// System.String EasyButtons.ButtonAttribute::Name
	String_t* ___Name_0;
	// EasyButtons.ButtonMode EasyButtons.ButtonAttribute::<Mode>k__BackingField
	int32_t ___U3CModeU3Ek__BackingField_1;
	// EasyButtons.ButtonSpacing EasyButtons.ButtonAttribute::<Spacing>k__BackingField
	int32_t ___U3CSpacingU3Ek__BackingField_2;
	// System.Boolean EasyButtons.ButtonAttribute::<Expanded>k__BackingField
	bool ___U3CExpandedU3Ek__BackingField_3;
};

// System.Void
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
#ifdef __clang__
#pragma clang diagnostic pop
#endif



// System.Void System.Attribute::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Attribute__ctor_m79ED1BF1EE36D1E417BA89A0D9F91F8AAD8D19E2 (Attribute_tFDA8EFEFB0711976D22474794576DAF28F7440AA* __this, const RuntimeMethod* method) ;
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
// System.Void EasyButtons.ButtonAttribute::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ButtonAttribute__ctor_m3ABF653F00162FC357438B43CCAF6D14DDF926B4 (ButtonAttribute_tC1B0F9DFC9D8073AEB558454AD8FE9E18EEC9394* __this, const RuntimeMethod* method) 
{
	{
		// public ButtonAttribute() { }
		Attribute__ctor_m79ED1BF1EE36D1E417BA89A0D9F91F8AAD8D19E2(__this, NULL);
		// public ButtonAttribute() { }
		return;
	}
}
// System.Void EasyButtons.ButtonAttribute::.ctor(System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ButtonAttribute__ctor_m6D2B68C9C10F3BAE6AE4CA5BC2F916E214815727 (ButtonAttribute_tC1B0F9DFC9D8073AEB558454AD8FE9E18EEC9394* __this, String_t* ___name0, const RuntimeMethod* method) 
{
	{
		// public ButtonAttribute(string name) => Name = name;
		Attribute__ctor_m79ED1BF1EE36D1E417BA89A0D9F91F8AAD8D19E2(__this, NULL);
		// public ButtonAttribute(string name) => Name = name;
		String_t* L_0 = ___name0;
		__this->___Name_0 = L_0;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___Name_0), (void*)L_0);
		return;
	}
}
// EasyButtons.ButtonMode EasyButtons.ButtonAttribute::get_Mode()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t ButtonAttribute_get_Mode_mE9E9B4D450B85E79796985E6272AC02F6480BFBC (ButtonAttribute_tC1B0F9DFC9D8073AEB558454AD8FE9E18EEC9394* __this, const RuntimeMethod* method) 
{
	{
		// public ButtonMode Mode { get; set; } = ButtonMode.AlwaysEnabled;
		int32_t L_0 = __this->___U3CModeU3Ek__BackingField_1;
		return L_0;
	}
}
// System.Void EasyButtons.ButtonAttribute::set_Mode(EasyButtons.ButtonMode)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ButtonAttribute_set_Mode_mBEB22CD79CC0B6AEF947B07636551A88D28DBA07 (ButtonAttribute_tC1B0F9DFC9D8073AEB558454AD8FE9E18EEC9394* __this, int32_t ___value0, const RuntimeMethod* method) 
{
	{
		// public ButtonMode Mode { get; set; } = ButtonMode.AlwaysEnabled;
		int32_t L_0 = ___value0;
		__this->___U3CModeU3Ek__BackingField_1 = L_0;
		return;
	}
}
// EasyButtons.ButtonSpacing EasyButtons.ButtonAttribute::get_Spacing()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t ButtonAttribute_get_Spacing_mE50B8241003851EC966502D42B340B16E31F7A7C (ButtonAttribute_tC1B0F9DFC9D8073AEB558454AD8FE9E18EEC9394* __this, const RuntimeMethod* method) 
{
	{
		// public ButtonSpacing Spacing { get; set; } = ButtonSpacing.None;
		int32_t L_0 = __this->___U3CSpacingU3Ek__BackingField_2;
		return L_0;
	}
}
// System.Void EasyButtons.ButtonAttribute::set_Spacing(EasyButtons.ButtonSpacing)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ButtonAttribute_set_Spacing_mCD13E4833B1201C853972AB8C5EA3693E9CD9A3A (ButtonAttribute_tC1B0F9DFC9D8073AEB558454AD8FE9E18EEC9394* __this, int32_t ___value0, const RuntimeMethod* method) 
{
	{
		// public ButtonSpacing Spacing { get; set; } = ButtonSpacing.None;
		int32_t L_0 = ___value0;
		__this->___U3CSpacingU3Ek__BackingField_2 = L_0;
		return;
	}
}
// System.Boolean EasyButtons.ButtonAttribute::get_Expanded()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool ButtonAttribute_get_Expanded_m0DB711352882C3682A1E49937D800E2245F2C8F5 (ButtonAttribute_tC1B0F9DFC9D8073AEB558454AD8FE9E18EEC9394* __this, const RuntimeMethod* method) 
{
	{
		// public bool Expanded { get; set; }
		bool L_0 = __this->___U3CExpandedU3Ek__BackingField_3;
		return L_0;
	}
}
// System.Void EasyButtons.ButtonAttribute::set_Expanded(System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ButtonAttribute_set_Expanded_m644F544F9B664AB35D88D5603A35CF3012A8A864 (ButtonAttribute_tC1B0F9DFC9D8073AEB558454AD8FE9E18EEC9394* __this, bool ___value0, const RuntimeMethod* method) 
{
	{
		// public bool Expanded { get; set; }
		bool L_0 = ___value0;
		__this->___U3CExpandedU3Ek__BackingField_3 = L_0;
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
