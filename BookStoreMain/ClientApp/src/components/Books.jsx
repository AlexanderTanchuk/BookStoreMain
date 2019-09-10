import React, { Component } from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { Link } from 'react-router-dom';
import { actionCreators } from '../store/Books';
import DropDownAuthors from './DropdownField';

class Books extends Component {
  constructor(props) {
    super(props);
    console.log("Books constructor called");
  }

  componentWillMount() {
    // This method runs when the component is first added to the page
    console.log("Books WillMount called");
    this.props.requestBooks();
  }

  componentWillReceiveProps(nextProps) {
    // This method runs when incoming props (e.g., route params) change
    console.log("Books WillReceiveProps called");
  }

  render() {
    console.log("Books Render called");
    return (
      <div>
        <h1>Books</h1>
        <p>This component demonstrates fetching data from the server and working with URL parameters.</p>
        {this.renderBooksTable()}
      </div>
    );
  }

  renderBooksTable() {
    return (
      <table className='table'>
        <thead>
          <tr>
            <th>Name</th>
            <th>Authors</th>
            <th>Genre</th>
            <th>Price</th>
            <th>Total Amount</th>
          </tr>
        </thead>
        <tbody>
          {this.props.books.map(book =>
            <tr key={book.id}>
              <td>{book.name}</td>
              <DropDownAuthors title="Books" lines={book.authors} />
              <td>{book.genre.name}</td>
              <td>{book.price}</td>
              <td>{book.totalAmount}</td>
            </tr>
          )}
        </tbody>
      </table>
    );
  }
}
function mapStateToProps(state) {
  console.log("Books MSTP called");
  return state.books_list;
}

export default connect(
  mapStateToProps,
  dispatch => bindActionCreators(actionCreators, dispatch)
)(Books);