param
(    
    [string] $githubHandle,
    [string] $AzureCredentialsJson,
    [string] $InitialPassword,
    [bool] $runLocal = $true
)


function GetADUserPrincipleName {
    param 
    (
        [string] $userName
    )

        return "$($userName)@xebiacommunityeventsoutlook.onmicrosoft.com"
    
}

function Execute-AAD 
{
    param (
        [string] $githubHandle,
        [string] $AzureCredentialsJson,
        [string] $InitialPassword
    )
    
        #Read Json string and convert to object
        $AzureCredentials = ConvertFrom-Json $AzureCredentialsJson
    
        az login --allow-no-subscriptions --service-principal -u $($AzureCredentials.clientId) -p $($AzureCredentials.clientSecret) --tenant $($AzureCredentials.tenantId)
        $userObject = CreateAADUser -githubHandle $githubHandle -InitialPassword $InitialPassword
        AddADUserToResourceGroup -ResourceGroup "rg-$($githubHandle)" -AADUserId $($userObject.id) -role "Owner"

    }    


function  CreateAADUser {
    param
    (
        [string] $githubHandle,
        [string] $InitialPassword
    )

    $userprincipalname = GetADUserPrincipleName -userName $githubHandle
    $allADUsers = az ad user list | ConvertFrom-Json
    try {
        $foundExistingUser = $allADUsers | Where-Object { $_.userPrincipalName -eq $userprincipalname } 

        if ($null -eq $foundExistingUser) {                
            $password = $InitialPassword
            $user = az ad user create --display-name $githubHandle --password $($password) --user-principal-name $($userprincipalname) | ConvertFrom-Json
            Write-Host "Created AAD User with userprincipalname [$($userprincipalname)]"
            return $user
        }
        else {
            Write-Host "User [$($displayName)] already exists, skipping creation"
            return $foundExistingUser
        }
    }
    catch {        
        $ErrorMessage = $_.Exception.Message
        Write-Host "Error creating User [$($displayName)]: $ErrorMessage"
    }
}

function AddADUserToResourceGroup {
    param
    (
        [string] $ResourceGroup,
        [string] $AADUserId,
        [string] $role
    )

    # Get existing assignments
    $existingAssignment = az role assignment list --assignee $AADUserId --resource-group $ResourceGroup --role $role | ConvertFrom-Json

    if ($null -eq $existingAssignment) {
        try {
            az role assignment create --role $role --assignee-object-id $AADUserId --resource-group $ResourceGroup
        }
        catch {        
            $ErrorMessage = $_.Exception.Message
            Write-Host "Error adding the AAD Group [$($AADUserGroupName)] to the resourcegroup [$($GroupName)]: $ErrorMessage"
        }
    }
    else {
        Write-Host "AADGroup [$($AADUserGroupName)] already has rights in the resourcegroup"
    }
}


if ($runLocal -eq $false) {
    Execute-AAD -githubHandle $githubHandle -AzureCredentialsJson $AzureCredentialsJson -InitialPassword $InitialPassword
}


