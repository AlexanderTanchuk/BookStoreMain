const requestAuthorsType = 'REQUEST_AUTHORS_LIST';
const receiveAthoursType = 'RECEIVE_AUTHORS_LIST';
const initialState = { authors: [], isLoading: false };

export const actionCreators = {
  requestAuthors: () => async (dispatch, getState) => {
    dispatch({ type: requestAuthorsType });

    const url = 'api/Authors';
    const response = await fetch(url);
    const authors = await response.json();

    dispatch({ type: receiveAthoursType, authors });
  }
};

export const reducer = (state, action) => {
  state = state || initialState;

  if (action.type === requestAuthorsType) {
    return {
      ...state,
      isLoading: true
    };
  }

  if (action.type === receiveAthoursType) {
    return {
      ...state,
      authors: action.authors,
      isLoading: false
    };
  }

  return state;
}