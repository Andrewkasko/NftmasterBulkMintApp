# NFTMASTER - Bulk mint application

### About
Minting NFTs and signing large amounts of transactions on the XRP ledger can be an extremely time consuming and tedious process especially if the user is required to scan a qr code for each transaction. We have built two open source applications ("NftmasterBulkMintApp" & "NftmasterBulkOfferApp") that we plan on merging into one to solve this issue.  

NFTMASTER was fortunate enough to receive a grant from Ripple in Wave 2. Within this grant we developed XLS-20 functionality that heavily revolved around the XUMM wallet which our users loved. However, once they knew how to mint 1 NFT they started to ask questions about signing hundreds/thousands of transactions and not just one at a time. We then developed both open source applications to solve seperate issues, one for minting and the other for signing offers.  Another wave of funding will allow our team to build a robust all in one version of the application that other developers will also be able to get inspiration off.

### Why it's important 
The XRP ledger is great however, in the words of David Schwartz it's only as good as the applications around it. Our goal is to allow anyone (regardless if you are a developer or not) to be able to mint collections fast, easily and efficiently on the XRP ledger.

### How it fits in with www.nftmaster.com
www.nftmaster.com will handle the bulk of the information upload. E.g. users can upload metadata about there collections and all their assets (images, video, audio, etc.) The nftmaster website will handle the pinning of assets to IPFS and the new bulk signing application will handle the signing of the transactions to the public ledger.

### The need for opensource
To sign each transaction without the need of XUMM, users must use their Xrp Address and their secret seed. With this in mind we aim to build a trustless system, meaning an external developer can see that we are not doing anything harmful to the user and their seed. 

### Public API 
In the case that a developer doesn't want to use the ntmaster bulk signing application but they still want nftmaster to pin their assets to IPFS. They can create a batch on the nftmaster site and pull the batch using our API and sign it using their own script.

### Video Tutorials 
* How to add the XLS-20D devnet to Xumm (https://youtu.be/LqwK35svTRI)
* How to burn a NFT (XRPL XLS-20D) (https://youtu.be/IRywrki3oTk)
* How to mint NFTs (XRPL - XLS-20D) (https://youtu.be/xNTpKftkq6Q)
* Bulk Mint NFTs (XRPL - XLS-20D) (https://youtu.be/aNDDVyylOCo)
* How to convert IOU tokens to NFTs on the XRP ledger (https://youtu.be/1Q2HYypvzIk)

# Getting started
1. Download Visual Studio 2022 Preview - Preview edition will allow you to access .net maui which is a framework to develop applications using .net on multiple formats e.g. desktop application, website, mobile application, etc.

2. Run the application.

3. Create a batch on the nftmaster website. To do this follow the video instructions in "Bulk Mint NFTs" or "How to convert IOU tokens to NFTs on the XRP Ledger".

4. Enter the batch id into the application, it will fetch the entire batch using the nftmaster API.

5. Once your batch has been fetched, enter your Xrp Address and your secret to sign all the transactions. You can visit an explorer such as https://nft-devnet.xrpl.org/ to see the transactions on the dev net as they are being signed.

Done!
