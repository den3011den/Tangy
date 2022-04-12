redirectToCheckout = function (sessionId) {
    var stripe = Stripe("pk_test_51KnoH0AkFudncz6FoNYVHKghHkRmlj7SLWDNjB8e3klyQ3oLGHgHmLEgj99aO4SqG1fFlPDM4LhoqIgm1s0iNwR800sCW1GTUn");
    stripe.redirectToCheckout({ sessionId: sessionId });
}