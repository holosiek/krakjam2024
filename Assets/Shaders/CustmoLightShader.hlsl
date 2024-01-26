#if SHADERGRAPH_PREVIEW
	Direction = half3(0.5,0.5,0);

#else
	Light light = GetMainLight();
	Direction = light.direction;
#endif