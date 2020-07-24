# ColourfulFlashPoints
 a small mod for HBS Battletech that allows you to customize the colour of the flashpoint indicators on the starmap 
 and flashpoint and contract cards on the contract selection screen

## Settings JSON

### Settings Object
this is the top level of the json file

example:
```json
{
  "debug" : true,
  "markers" : [],
  "contractMarkers": []
}
```

`debug` - true to turn additional debug logging on, false to turn it off

`markers` : a list of `FpMarker` objects, these detail the colour changes to use for various flashpoints

`contractMarkers` : a list of `ContractMarker` objects, these detail how to change the contract card colours for 
normal contracts


### Colour Object
this object is used to denote the colours that FpMarkers and ContractMarker objects should apply

example 1:
```json
{
    "Colour": "#0B8E12",
    "Alpha" : 0.44 
}
```

example 2:
```json
{
    "Colour": "#0B8E12"
}
```

`Colour` - a html colour code that represents the colour to be used. the format is `#RRGGBB` where `RR`, `GG` & `BB` 
are each a hex encoded value from `00` - `FF`

`Alpha` - the alpha layer to be applied to the colour (the transparency). this is a floating point value from
`0.0` - `1.0`. if not defined a default of `1.0` is used.

### FpMarker

this object controls the colour of the flashpoint animation and contract cards. it also allows the Heavy Metal 
flashpoint-campaign animation to be used. 

example 1
```json
{
    "useHmAnimation": true,
    "flashpointPrefix" : "fp_longRoad",
    "swapColour" : true,
    "innerCircle" :
    {
       "Colour": "#8E0B0B",
       "Alpha" : 0.35 
    }
}
```

example 2
```json
{
    "useHmAnimation": true,
    "flashpointPrefix" : "fp_uw1",
    "swapColour" : true,
    "keepAlpha" : true,
    "useOnlyInner": false,
    "autoDetectContracts" : false,
    "useContractColourOverride" : true,
    "innerCircle" :
    {
       "Colour": "#2E1B1F"
    },
    "dottedHmRing" :
    {
       "Colour": "#9E0B0B"
    },
    "innerHmPulsing" :
    {
       "Colour": "#8E3B0B"
    },
    "outerCircle" :
    {
       "Colour": "#8E0B4B" 
    },
    "outerPulsing" :
    {
       "Colour": "#8E0B5B"
    },
    "outerPulsingFill" :
    {
       "Colour": "#2E1BAB" 
    },
    "contractColour" :
    {
       "Colour": "#8E0B0B",
       "Alpha" : 0.35 
    },
    "contractIds": [
    "uw_prototype_1_1_attack"
    ]
    }
```

`useHmAnimation` - controls whether the Heavy Metal animation is used (true) or the standard one (false). 
**Note: Heavy Metal DLC is not required to use the animation**

`flashpointPrefix` - the prefix used to match this marker to a flashpoint based on its ID. any flashpoint whose ID 
starts with this prefix will be matched to this marker (in the event multiple markers match the first one found 
will be used). this allows multiple related flashpoints to be matched for example `fp_long` would match to both 
the longRoad and longWar flashpoints or `fp_HM` would match to all the HM flashpoint campaign flashpoints.

`swapColour` - true to alter the flashpoints colours, false to leave them as the default. if not specified this is set 
to false by default

`keepAlpha` - true to ignore the alpha values for the animation colour changes and leave the standard values in place. 
default value is true 
**Note: the Contract card colour will always use the alpha value from here regardless of this setting**

`useOnlyInner` - when true use the `innerCircle` colour for all colours in the animation, false to use different 
colours for all components of the animation. default value is true

`autoDetectContracts` - when true attempt to auto-associate flashpoint contracts with this marker based on the ID of 
the contract. matching is strips the `c_` from the start of contract ID (if its there) and then attempts to match 
based on the flashpoint prefix. this works for most vanilla flashpoint contracts (the UW prototype does not follow this
naming convention and therefore doesnt work). when false contract IDs must be given to match contracts with the marker

`useContractColourOverride` - when true contract cards will have their colour changed the value specified by the 
`contractColour` element. when false the `innerCircle` element will be used. if `swapColour` is false, this field is 
ignored default value is false. 

`contractIds` - a list of contract IDs to associate with this flashpoints matched to this marker.
 
 `innerCircle` - the `Colour Object` of the inner most element of the flashpoint element. if `useOnlyInner` is true then 
 this value will be applied to all parts of the animation. like all colour elements this will be ignored if 
 `swapColour` is set to false
 
`dottedHmRing` - the `Colour Object` of the dotted ring element of the HM flashpoint element. 
like all colour elements this will be ignored if `swapColour` is set to false or `useOnlyInner` is true. 
**Note: this is only applicable if the HM animation is being used**

`innerHmPulsing` - the `Colour Object` of the inner pulsing element of the HM flashpoint element. 
like all colour elements this will be ignored if `swapColour` is set to false or `useOnlyInner` is true. 
**Note: this is only applicable if the HM animation is being used**

`outerCircle` - the `Colour Object` of the outer circle element of the flashpoint element. 
like all colour elements this will be ignored if `swapColour` is set to false or `useOnlyInner` is true.

`outerPulsing` - the `Colour Object` of the outer pulsing element of the flashpoint element. 
like all colour elements this will be ignored if `swapColour` is set to false or `useOnlyInner` is true.

`outerPulsingFill` - the `Colour Object` of that fills outer circle pulsing element of the flashpoint element. 
like all colour elements this will be ignored if `swapColour` is set to false or `useOnlyInner` is true.

`contractColour` - the `Colour Object` of the contract card element. 
this will be ignored if `swapColour` is set to false or `useContractColourOverride` is false.

### ContractMarker

This is used to control the colour of non-flashpoint and non-priority contract cards in the contract list screen.
in the event more than one marker can be matched to a contract, the first one matched is applied

```json
{
    "type" : "ContractType",
    "contractIds" : 
    [
      "SimpleBattle"    
    ],
    "colour": 
    {
        "Colour": "#0B8E12",
        "Alpha" : 0.44 
    }
}
```

`type` - used to control how contracts are matched to this marker. the following values are valid

    - ContractType - match based on the contract type (ie. simpleBattle, DestroyBase)
    - ContractId - match based on the ID field of the contract
    - ContractName - match based on the Name of the contract
    
`contractIds` - a list used to match. what should be in here will depend on the `type` field

`colour` - the `Colour Object` to be used when this marker is matched

