const requestBooksType = 'REQUEST_BOOKS_LIST';
const receiveBooksType = 'RECEIVE_BOOKS_LIST';
const initialState = { books: [], isLoading: false };

export const actionCreators = {
  requestBooks: () => async (dispatch, getState) => {
    dispatch({ type: requestBooksType });

    const url = 'api/Books';
    const response = await fetch(url);
    const books = await response.json();

    dispatch({ type: receiveBooksType, books });
  }
};

export const reducer = (state, action) => {
  state = state || initialState;

  if (action.type === requestBooksType) {
    return {
      ...state,
      isLoading: true
    };
  }

  if (action.type === receiveBooksType) {
    return {
      ...state,
      books: action.books,
      isLoading: false
    };
  }

  return state;
}