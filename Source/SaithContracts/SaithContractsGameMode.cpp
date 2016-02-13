// Copyright 1998-2015 Epic Games, Inc. All Rights Reserved.

#include "SaithContracts.h"
#include "SaithContractsGameMode.h"
#include "SaithContractsCharacter.h"

ASaithContractsGameMode::ASaithContractsGameMode()
{
	// set default pawn class to our character
	DefaultPawnClass = ASaithContractsCharacter::StaticClass();	
}
