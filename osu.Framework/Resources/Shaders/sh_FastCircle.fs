#ifndef FAST_CIRCLE_FS
#define FAST_CIRCLE_FS

#undef HIGH_PRECISION_VERTEX
#define HIGH_PRECISION_VERTEX

#include "sh_Utils.h"
#include "sh_Masking.h"

layout(location = 2) in highp vec2 v_TexCoord;

layout(location = 0) out vec4 o_Colour;

void main(void)
{
    const float smoothness = 1.5; // in screen-space

    highp vec2 pixelPos = v_TexRect.zw * 0.5 - abs(v_TexCoord - v_TexRect.zw * 0.5);
    highp float radius = min(v_TexRect.z, v_TexRect.w) * 0.5;

    highp float dst = max(pixelPos.x, pixelPos.y) > radius ? radius - min(pixelPos.x, pixelPos.y) : distance(pixelPos, vec2(radius));

    highp float alpha = smoothstep(radius, radius - smoothness, dst);

    o_Colour = getRoundedColor(vec4(vec3(1.0), alpha), vec2(0.0));
}

#endif
